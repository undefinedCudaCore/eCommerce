using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Models.UserModels;

namespace eCommerce.Service.UserServices

{
    internal class UserLoginService
    {
        internal UserLoginErrors Login(string username, string password, out User _user)
        {
             _user = null;
            RegistrationService _service = new RegistrationService();

            UserLoginErrors errors = new UserLoginErrors();

            if ((errors=_service.Login(username, password, out int _userId, out eUserType _userType)).success)
            {
                Console.WriteLine(_userId);
                Console.WriteLine(Enum.GetName(typeof(eUserType), _userType));

                _user = new User(_userId, _userType, username);

                UsersDatabaseService database = new UsersDatabaseService();
                _user = database.LoadUserData(_user);

                return errors;

            }
            else
            {

            return errors;
            }
        }
    }
}
