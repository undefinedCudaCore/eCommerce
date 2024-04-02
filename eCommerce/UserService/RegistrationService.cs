using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using  eCommerce;

namespace eCommerce
{



        public class RegistrationService
        {

            public bool Register(string username, string password)
            {
                Security _secrets = new Security();

                var users = _secrets.LoadUsers();

                if (users.ContainsKey(username))
                {
                    return false;
                    // this username is already taken
                }

                var salt = _secrets.GenerateSalt();
                var saltedPassword = password + salt;
                var hashedPassword = _secrets.HashPassword(saltedPassword);

            UInt32 lastUserId = 0;
            if (users.Count > 0)
            {
                 lastUserId = users[users.Keys.ElementAt(users.Count-1)].UserID;
            }
                users.Add (username, new UserForLog { Salt = salt, HashedPassword = hashedPassword, UserID = lastUserId + 1 });

                _secrets.SaveUsers(users);
                return true;
            }

            public bool RegisterAdmin(string username, string password, eUserType userType, string adminPassword)
            {
                if (adminPassword != "parduotuve")
                    return false;

                Security _secrets = new Security();

                var users = _secrets.LoadUsers();

                var salt = _secrets.GenerateSalt();
                var saltedPassword = password + salt;
                var hashedPassword = _secrets.HashPassword(saltedPassword);
                users[username] = new UserForLog { Salt = salt, HashedPassword = hashedPassword, UserType = eUserType.ADMINISTRATOR };

                _secrets.SaveUsers(users);
                return true;
            }

            public bool Login(string username, string password, out UInt32 userId, out eUserType userType)
            {
                Security _secrets = new Security();
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
