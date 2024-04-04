using eCommerce.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.UserServices
{
    internal class UserManagementService
    {
        /// <summary>
        ///  this returns users that have registered in shop
        /// </summary>
        /// <returns></returns>
        internal List <string> GetRegisteredUsersList ()
        {
             List<string> RegisteredUsers = new List<string> ();
            SecurityService _secrets = new SecurityService();
            var users = _secrets.LoadUsers();

            foreach (var user in users) 
            {
                RegisteredUsers.Add(user.Key);
            }

            return RegisteredUsers;
        }

        /// <summary>
        ///  this returns users that have connected atleast once in outr shop
        /// </summary>
        /// <returns></returns>
        internal List<string> GetCustomersListUsersList()
        {
            List<string> CustomersList = new List<string>();
            SecurityService _secrets = new SecurityService();
            var Customers = _secrets.LoadUsers();
            UsersDatabaseService _usersDatabaseService = new UsersDatabaseService();
            var LoggedUsers = _usersDatabaseService.LoadDatabase();

            foreach (var user in Customers)
            {
                if (LoggedUsers.ContainsKey(user.Value.UserID))
                {

                    CustomersList.Add($"Username {LoggedUsers[user.Value.UserID].Username}, Name {LoggedUsers[user.Value.UserID].Name}, Surname {LoggedUsers[user.Value.UserID].Surname}");
                }
            }

            return CustomersList;
        }



    }
}
