using eCommerce.Models.UserModels;
using eCommerce.Service;
using eCommerce.Service.UserServices;
using Microsoft.Win32;


namespace eCommerce
{
    public class Program
    {
        static void Main(string[] args)
        {
            {

                var list = new List<User>();
               // list.Add(new User("Alma", "password", 20.4));
               // list.Add(new User("Bob", "password", 75.2));

                User _user;

                
                UserRegistration.Register("Karolis", "lala1", eUserType.ADMINISTRATOR);
                UserRegistration.Register("Karolis1", "lala1", eUserType.CUSTOMER);
                UserRegistration.Register("Karolis2", "lala2", eUserType.MANAGER);

                UserLoginErrors loginErrors;


                if  ((loginErrors = UserLoginService.Login("Karolis1", "lala1", out User user)).success)
                {
                    _user = user;

                } else
                {
                    Console.WriteLine(loginErrors.UserBlockedUntil);
                }

               //_user = UserLoginService.Login("Karolis1", "la1");

               // AppendBalanceService balanceService = new AppendBalanceService();

               //// balanceService.UpdateBalance(_user, 800);

               // _user = UserLoginService.Login("Karolis2", "lala2");

               // _user = UserLoginService.Login("Karolis", "lala1");



                CheckBalanse.CheckBalanceNow(list);
                //AppendBalance.AddToBalance(list);
                CheckBalanse.CheckBalanceNow(list);

            }

            //CreateShopItemService.CreateItem("1", "iPhone", "Not very good phone.", "Smartphone", 999.99);
        }
    }
}
