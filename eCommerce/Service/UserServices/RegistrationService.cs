using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Models.UserModels;
using Newtonsoft.Json;

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
            UsersDatabaseService database = new UsersDatabaseService();
            return true;
        }



        public bool Login(string username, string password, out int userId, out eUserType userType)
        {
            SecurityService _secrets = new SecurityService();
            var users = _secrets.LoadUsers();

            userId = 0;
            userType = eUserType.UNDEFINED;

            if (!users.ContainsKey(username))
            {
                return false;
            }

            var user = users[username];
            var saltedPassword = password + user.Salt;
            var hashedPassword = _secrets.HashPassword(saltedPassword);
            if (user.HashedPassword == hashedPassword)
            {
                userId = user.UserID;
                userType = user.UserType;
                return true;
            }
            return false;
        }




    }


}
