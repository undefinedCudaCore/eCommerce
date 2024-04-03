using eCommerce.Service;
using eCommerce;
using eCommerce.UserService;

namespace eCommerce
{
    public class Program
    {
        static void Main(string[] args)
        {
            {

                var list = new List<User>();
                list.Add(new User("Alma", "password", 20.4));
                list.Add(new User("Bob", "password", 75.2));
                User _user;


                RegistrationService _service = new RegistrationService();


                string username = "Karolis";
                string password = "Norvaisa";

                _service.Register(username, password);
                _service.Register(username+1, password+1);

                _service.Register(username+2, password+2);


                if (_service.Login(username, password, out int _userId, out eUserType _userType))
                {
                    Console.WriteLine(_userId);
                    Console.WriteLine(Enum.GetName(typeof(eUserType), _userType));

                    _user = new User(_userId, _userType, username);

                    UsersDatabase database = new UsersDatabase();
                    _user = database.LoadUserData(_user);
                }

                if (_service.Login(username +2, password+2, out  _userId, out  _userType))
                {
                    Console.WriteLine(_userId);
                    Console.WriteLine(Enum.GetName(typeof(eUserType), _userType));

                    _user = new User(_userId, _userType, username);

                    UsersDatabase database = new UsersDatabase();
                    _user = database.LoadUserData(_user);
                }


                CheckBalanse.CheckBalanceNow(list);
                //AppendBalance.AddToBalance(list);
                CheckBalanse.CheckBalanceNow(list);

            }
        }
    }
}
