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
        ///  removes user from login database by its id
        /// </summary>
        /// <returns></returns>
        internal UserManagementErrors RemoveUserById(int Id)
        {
            UserManagementErrors errors=new UserManagementErrors();
            Dictionary<int, string> RegisteredUsers = new Dictionary<int, string>();
            SecurityService _secrets = new SecurityService();
            var users = _secrets.LoadUsers();

            var user = users.FirstOrDefault(u => u.Value.UserID == Id);
            if (user.Key != null && users.ContainsKey(user.Key) )
            {
                users.Remove(user.Key);
                _secrets.SaveUsers(users);
                errors.success = true;
                errors.Message = "User removed succesfully";
            } else
            {
                errors.UserNotExits = true;
                errors.Message = "This user was not found in our database";
            }

            return errors;
        }

        /// <summary>
        ///  this returns users that have registered in shop
        /// </summary>
        /// <returns></returns>
        internal Dictionary <int,string> GetRegisteredUsersList ()
        {
            Dictionary<int, string> RegisteredUsers = new Dictionary<int, string>();
            SecurityService _secrets = new SecurityService();
            var users = _secrets.LoadUsers();

            foreach (var user in users) 
            {
                RegisteredUsers.Add(user.Value.UserID , $"Username {user.Key} UserRole {(eUserType)user.Value.UserType}");
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
