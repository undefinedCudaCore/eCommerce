using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Models.UserModels;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eCommerce.Service.UserServices
{



    public class RegistrationService
    {

        public bool Register(string username, string password, eUserType userType, out int userId)
        {
            SecurityService _secrets = new SecurityService();
            userId = 0;
            var users = _secrets.LoadUsers();

            if (users.ContainsKey(username))
            {
                return false;
                // this username is already taken
            }

            var salt = _secrets.GenerateSalt();
            var saltedPassword = password + salt;
            var hashedPassword = _secrets.HashPassword(saltedPassword);

            int lastUserId = 0;
            if (users.Count > 0)
            {
                lastUserId = users[users.Keys.ElementAt(users.Count - 1)].UserID;
            }
            userId = lastUserId;
            users.Add(username, new UserForLog { Salt = salt, HashedPassword = hashedPassword, UserID = lastUserId + 1, UserType = userType });

            _secrets.SaveUsers(users);

            return true;
        }



        public UserLoginErrors Login(string username, string password, out int userId, out eUserType userType)
        {
            UserLoginErrors errors= new UserLoginErrors();
            SecurityService _secrets = new SecurityService();
            var users = _secrets.LoadUsers();

            userId = 0;
            userType = eUserType.UNDEFINED;

            if (!users.ContainsKey(username))
            {
                errors.UserNotExits = true;

                return errors;
            }

            var user = users[username];

            if (user.NextConnectAttempt > DateTime.Now)
            {
                errors.UserBlockedUntil = user.NextConnectAttempt;
                errors.Message = "Due multiple bad logins this user is blocked for  " + (errors.UserBlockedUntil - DateTime.Now).TotalSeconds.ToString() + "seconds ";
                return errors;
            }



            var saltedPassword = password + user.Salt;
            var hashedPassword = _secrets.HashPassword(saltedPassword);
            if (user.HashedPassword == hashedPassword)
            {
                user.FailedConnectAttempts = 0;
                userId = user.UserID;
                userType = user.UserType;
                errors.success = true;
                return errors;

            }else
            {
                user.FailedConnectAttempts += 1;

                if (user.FailedConnectAttempts == 3)
                {
                    user.NextConnectAttempt = DateTime.Now.AddSeconds(120);
                    errors.Message = "User is Blocked until " + user.NextConnectAttempt + " If you enter bad password again you will be blocked until " + DateTime.Now.AddSeconds(600);
                }
                else if (user.FailedConnectAttempts == 4)
                {
                    user.NextConnectAttempt = DateTime.Now.AddSeconds(600);
                    user.FailedConnectAttempts = 0;
                    errors.Message = "User is Blocked until " + user.NextConnectAttempt;

                }

                errors.TriesLeft = 4 - user.FailedConnectAttempts;

                users[username] = user;
                _secrets.SaveUsers(users);

                return errors;

            }
        }




    }
}
