using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service

{
    internal static class UserLogin
    {
        public static User Login(string username, string password)
        {
            User _user;
            RegistrationService _service = new RegistrationService();

            if (_service.Login(username, password, out int _userId, out eUserType _userType))
            {
                Console.WriteLine(_userId);
                Console.WriteLine(Enum.GetName(typeof(eUserType), _userType));

                _user = new User(_userId, _userType, username);

                UsersDatabase database = new UsersDatabase();
                _user = database.LoadUserData(_user);
                return _user;


            }
            else return null;
        }
    }
}
