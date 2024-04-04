using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service
{
    public static  class UserRegistration
    {



        // _service.Register(username, password);
        // _service.Register(username+1, password+1);

        public static bool Register(string username, string password, eUserType _userType)
        {
            RegistrationService _service = new RegistrationService();

            if (_service.Register(username, password, _userType, out int userId))
            {


                return true;
            }
            else return false;
        }
}
}


