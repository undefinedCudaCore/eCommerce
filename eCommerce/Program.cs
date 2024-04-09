using eCommerce.Models.ShopCart;
using eCommerce.Models.UserModels;
using eCommerce.Service;
using eCommerce.Service.ShopService.ItemService;
using eCommerce.Service.UserServices;

namespace eCommerce
{
//    Prisijungimą
//Registracija(neteisingai mėginant prisijungti 3 ar daugiau kartų turėtų būti užblokuotas prisijungimas
//Galimybę peržiūrėti savo turimą balansą
//Galimybę papildyti savo balansą
//Peržiūrėti sistemoje esančias prekes
//Įsidėti sistemoje esančias prekes į krepšelį ir jį išsaugoti
//Nusipirkti krepšelyje esančias prekes
//Atsijungti


    internal enum eShopStates
    {
        USER_REGISTRATION,
        USER_LOGIN,
        USER_LOGOUT,
        SHOW_MAINMENU,
        SHOW_ADMINMENU,
        SHOW_USERMENU
    };
    internal enum eUserMenu
    {
        USER_VIEW_BALANCE,
        USER_ADD_BALANCE,
        USER_VIEW_PRODUCTS,
        USER_VIEW_CART,
        USER_BUY_CART,
        USER_USERMENU_RETURN

    };

    internal enum eAdminMenu
    {
        ADMIN_MENU,
        ADD_NEW_PRODUCT,
        ADD_STOCK,
        REMOVE_PRODUCT,
        VIEW_REGISTERED_USERS,
        VIEW_CUSTOMERS,
        REMOVE_USER,
        RETURN

    }
    public class Program
    {
        static void Main(string[] args)
        {
            eShopStates ShopStates = eShopStates.SHOW_MAINMENU;
            eAdminMenu AdminMenu = eAdminMenu.ADMIN_MENU;
            eUserMenu userMenu;
            UserManagementService userManagement = new UserManagementService();
            UserManagementErrors userManagementErr;
            UserLoginErrors loginErrors;
            User currentUser = new User();
               AppendBalanceService appendBalanceService = new AppendBalanceService();


            UserLoginService loginService = new UserLoginService();

            ConsoleHelper CH = new ConsoleHelper();


            while (true)
            {
                switch (ShopStates)
                {
                    case eShopStates.SHOW_USERMENU:
                        while (true)
                        {
                            bool exitRequested = false;

                            Console.WriteLine("--User Menu--");

                            foreach (var state in Enum.GetValues(typeof(eUserMenu)))
                            {
                                Console.WriteLine($"[{(int)state}] {state}");
                            }

                            userMenu = (eUserMenu)CH.GetUserInputNumeric("", 0, Enum.GetValues(typeof(eUserMenu)).Cast<int>().Max() + 1);


                            switch (userMenu)
                            {
                                case eUserMenu.USER_VIEW_PRODUCTS:

                                    break;
                                case eUserMenu.USER_VIEW_BALANCE:
                                    
                                    Console.WriteLine(currentUser.Balance);
                                    break;
                                case eUserMenu.USER_VIEW_CART:

                                    break;
                                case eUserMenu.USER_BUY_CART:

                                    break;
                                case eUserMenu.USER_ADD_BALANCE:

                                    if (currentUser.UserId != 0)
                                    {
                                    appendBalanceService.UpdateBalance(currentUser, CH.GetUserInputNumeric("append amount - ", 1, 10000));
                                        Console.WriteLine("balance updated succesfuly");

                                    } else Console.WriteLine("user is not logged in");

                                    break;
                                case eUserMenu.USER_USERMENU_RETURN:
                                    exitRequested = true;
                                    break;

                            }
                            if (exitRequested) break;

                        }

                        ShopStates = eShopStates.SHOW_MAINMENU;

                        break;
                    case eShopStates.USER_REGISTRATION:

                        string name = "";
                        string password = "";
                        Console.Clear();
                        name = CH.GetUserInputString("Enter Username");
                        password = CH.GetUserInputString("Enter Password");
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


                        if ((loginErrors = loginService.Login(name, password, out User user)).success)
                        {
                            currentUser = user;
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

                    case eShopStates.USER_LOGOUT:
                        if (currentUser.UserId != 0)
                        {
                            currentUser = new User();
                            Console.WriteLine("User logged out");

                        }
                        else Console.WriteLine("user is not logged in");


                        Console.ReadKey();
                        ShopStates = eShopStates.SHOW_MAINMENU;

                        break;
                    case eShopStates.SHOW_MAINMENU:

                        if (currentUser.UserId == 0)
                        {
                            int count = 2;
                            foreach (var state in Enum.GetValues(typeof(eShopStates)))
                            {
                                Console.WriteLine($"[{(int)state}] {state}");
                                count++;
                                if (count > (int)eShopStates.SHOW_MAINMENU) break;
                            }
                            ShopStates = (eShopStates)CH.GetUserInputNumeric("", 0, (int)eShopStates.USER_LOGIN + 1);

                        }
                        else
                        {
                            foreach (var state in Enum.GetValues(typeof(eShopStates)))
                            {
                                Console.WriteLine($"[{(int)state}] {state}");

                            }
                            ShopStates = (eShopStates)CH.GetUserInputNumeric("", 0, Enum.GetValues(typeof(eShopStates)).Cast<int>().Max() + 1);
                        }

                        Console.ReadKey();

                        break;

                    case eShopStates.SHOW_ADMINMENU:

                        while (true)
                        {
                            bool exitRequested = false;
                            Console.WriteLine("--ADMIN MENU--");
                            foreach (var state in Enum.GetValues(typeof(eAdminMenu)))
                            {
                                Console.WriteLine($"[{(int)state}] {state}");
                            }

                            AdminMenu = (eAdminMenu)CH.GetUserInputNumeric("", 0, Enum.GetValues(typeof(eAdminMenu)).Cast<int>().Max() + 1);
                            switch (AdminMenu)
                            {
                                case eAdminMenu.ADMIN_MENU:
                                    break;
                                case eAdminMenu.ADD_NEW_PRODUCT:
                                    Console.Clear();
                                    CreateShopItemService createShopItemService = new CreateShopItemService();
                                    CollectNewItemDataExtention.CollectNewItemData(createShopItemService);
                                    break;
                                case eAdminMenu.ADD_STOCK:
                                    break;
                                case eAdminMenu.REMOVE_PRODUCT:
                                    break;
                                case eAdminMenu.VIEW_REGISTERED_USERS:


                                    foreach (var item in userManagement.GetRegisteredUsersList())
                                    {
                                        Console.WriteLine("user ID" + item.Key + " " + item.Value);
                                    }
                                    break;
                                case eAdminMenu.VIEW_CUSTOMERS:

                                    foreach (var item in userManagement.GetCustomersListUsersList())
                                    {
                                        Console.WriteLine(item);
                                    }

                                    break;
                                case eAdminMenu.REMOVE_USER:

                                    userManagementErr = userManagement.RemoveUserById(CH.GetUserInputNumeric("Enter ID to remove", 0, 9999));
                                    if (!userManagementErr.success)
                                    {
                                        Console.WriteLine($"Failed to remove user {userManagementErr.Message}");
                                    }
                                    else Console.WriteLine("User removes successfuly");
                                    break;
                                case eAdminMenu.RETURN:
                                    Console.Clear();
                                    exitRequested = true;
                                    break;

                            }
                            if (exitRequested) break;
                        }
                        ShopStates = eShopStates.SHOW_MAINMENU;

                        break;
                }
            }





          //  UserManagementService userManagement = new UserManagementService();

            //var users = userManagement.GetRegisteredUsersList();
            //UserManagementErrors errors = new UserManagementErrors();
            //errors = userManagement.RemoveUserById(1);

            //users = userManagement.GetRegisteredUsersList();

            //_user = UserLoginService.Login("Karolis1", "la1");

            // AppendBalanceService balanceService = new AppendBalanceService();

            //// balanceService.UpdateBalance(_user, 800);

            // _user = UserLoginService.Login("Karolis2", "lala2");

            // _user = UserLoginService.Login("Karolis", "lala1");

            //AppendBalanceService balanceService = new AppendBalanceService();
            //balanceService.UpdateBalance(currentUser, 100000);

            //CheckBalanse.CheckBalanceNow(currentUser);
            //AppendBalance.AddToBalance(list);
            //CheckBalanse.CheckBalanceNow(currentUser);


            //CreateShopItemService createShopItemService = new CreateShopItemService();
            //createShopItemService.CreateItem("1", "iPhone", "Not very good phone.", "Smartphone", 22999.00);
            //AddToCartServise addToCartServise = new AddToCartServise();
            //addToCartServise.AddToCartList(currentUser, CreateShopItemService.Item);

            //CheckShopItemService check = new CheckShopItemService();
            //check.ShowContent(currentUser);

            //DisplayCartService displayCartService = new DisplayCartService();
            //displayCartService.ShowContent(currentUser);

            //BuyItemService buyItemService = new BuyItemService();
            //buyItemService.BuyCartItems(currentUser);
            //buyItemService.ShowContent(currentUser);

            //CheckBalanse.CheckBalanceNow(currentUser);

        }

    }


}
