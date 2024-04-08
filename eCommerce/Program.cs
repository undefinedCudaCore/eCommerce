using eCommerce.Models.UserModels;
using eCommerce.Service;
using eCommerce.Service.ShopService.CartService;
using eCommerce.Service.UserServices;
using System.ComponentModel.Design;

namespace eCommerce
{
    internal enum eShopStates
    {
        USER_REGISTRATION,
        USER_LOGIN,
        USER_LOGOUT,
        SHOW_MAINMENU,
    };


    internal enum eAdminMenu
    {
        ADD_NEW_PRODUCT,
        ADD_STOCK,
        REMOVE_PRODUCT,
        VIEW_REGISTERED_USERS,
        VIEW_CUSTOMERS,
        REMOVE_USER
    }
    public class Program
    {
        static void Main(string[] args)
        {
        eShopStates ShopStates = eShopStates.SHOW_MAINMENU;

            ConsoleHelper CH = new ConsoleHelper();


            while (true)
            {
                switch (ShopStates)
                {
                    case eShopStates.USER_REGISTRATION:

                        string name = "";
                        string password = "";
                        Console.Clear();
                        name = CH.GetUserInputString("Enter Username");
                        password = CH.GetUserInputString("Enter Password");
                        Console.WriteLine("");
                        UserRegistrationService registrationService = new UserRegistrationService();

                        if (!(registrationService.Register(name, password, eUserType.ADMINISTRATOR))) 
                        {

                            Console.WriteLine("this user already exits in out database");
                        }
                        ShopStates = eShopStates.SHOW_MAINMENU;
                        break;

                    case eShopStates.USER_LOGIN:

                         name = "";
                         password = "";
                        Console.Clear();
                        name = CH.GetUserInputString("Enter Username");
                        password = CH.GetUserInputString("Enter Password");
                        Console.WriteLine("");
                        UserLoginErrors loginErrors;

                        UserLoginService loginService = new UserLoginService();

                        if ((loginErrors = loginService.Login(name, password, out User user)).success)
                        {
                            //currentUser = user;
                            Console.WriteLine("successfuly logged in");
                            Console.ReadKey();

                        }
                        else
                        {
                            Console.WriteLine(loginErrors.Message);
                            Console.ReadKey();
                        }
                        ShopStates = eShopStates.SHOW_MAINMENU;

                        break;
                    case eShopStates.SHOW_MAINMENU:

                        foreach (var state in Enum.GetValues(typeof(eShopStates)))
                        {
                            Console.WriteLine($"[{(int)state}] {state}");
                        }
                        ShopStates = (eShopStates)CH.GetUserInputNumeric("",0, Enum.GetValues(typeof(eShopStates)).Cast<int>().Max()+1);
                        Console.ReadKey();
                        break;
                }
            }

                        User currentUser = new User();




            UserManagementService userManagement = new UserManagementService();

            var users = userManagement.GetRegisteredUsersList();
            UserManagementErrors errors = new UserManagementErrors();
            errors = userManagement.RemoveUserById(1);

            users = userManagement.GetRegisteredUsersList();

            //_user = UserLoginService.Login("Karolis1", "la1");

            // AppendBalanceService balanceService = new AppendBalanceService();

            //// balanceService.UpdateBalance(_user, 800);

            // _user = UserLoginService.Login("Karolis2", "lala2");

            // _user = UserLoginService.Login("Karolis", "lala1");

            AppendBalanceService balanceService = new AppendBalanceService();
            //balanceService.UpdateBalance(currentUser, 100000);

            CheckBalanse.CheckBalanceNow(currentUser);
            //AppendBalance.AddToBalance(list);
            CheckBalanse.CheckBalanceNow(currentUser);


            //CreateShopItemService createShopItemService = new CreateShopItemService();
            //createShopItemService.CreateItem("1", "iPhone", "Not very good phone.", "Smartphone", 22999.00);
            //AddToCartServise addToCartServise = new AddToCartServise();
            //addToCartServise.AddToCartList(currentUser, CreateShopItemService.Item);

            //CheckShopItemService check = new CheckShopItemService();
            //check.ShowContent(currentUser);

            DisplayCartService displayCartService = new DisplayCartService();
            displayCartService.ShowContent(currentUser);

            BuyItemService buyItemService = new BuyItemService();
            buyItemService.BuyCartItems(currentUser);
            buyItemService.ShowContent(currentUser);

            CheckBalanse.CheckBalanceNow(currentUser);

        }

    }


}
