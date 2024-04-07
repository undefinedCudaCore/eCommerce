﻿using eCommerce.Models.UserModels;
using eCommerce.Service;
using eCommerce.Service.UserServices;
using Microsoft.Win32;
using eCommerce.Service.ShopService.CartService;
using eCommerce.Service.ShopService.ItemService;

namespace eCommerce
{
    public class Program
    {
        static void Main(string[] args)
        {
                var list = new List<User>();
            // list.Add(new User("Alma", "password", 20.4));
            // list.Add(new User("Bob", "password", 75.2));

            User currentUser = new User();



                UserRegistration.Register("Karolis", "lala1", eUserType.ADMINISTRATOR);
                UserRegistration.Register("Karolis1", "lala1", eUserType.CUSTOMER);
                UserRegistration.Register("Karolis2", "lala2", eUserType.MANAGER);

                UserLoginErrors loginErrors;


                if  ((loginErrors = UserLoginService.Login("Karolis1", "lala1", out User user)).success)
                {
                    currentUser = user;

                } else
                {
                    Console.WriteLine(loginErrors.Message);
                }
           
            UserManagementService userManagement = new UserManagementService();

                 var users = userManagement.GetRegisteredUsersList();
            UserManagementErrors errors = new UserManagementErrors();
            errors= userManagement.RemoveUserById(1);

            users = userManagement.GetRegisteredUsersList();

            //_user = UserLoginService.Login("Karolis1", "la1");

            // AppendBalanceService balanceService = new AppendBalanceService();

            //// balanceService.UpdateBalance(_user, 800);

            // _user = UserLoginService.Login("Karolis2", "lala2");

            // _user = UserLoginService.Login("Karolis", "lala1");



            CheckBalanse.CheckBalanceNow(list);
                //AppendBalance.AddToBalance(list);
                CheckBalanse.CheckBalanceNow(list);


            CreateShopItemService createShopItemService = new CreateShopItemService();
            //createShopItemService.CreateItem("1", "iPhone", "Not very good phone.", "Smartphone", 999.99);
            //AddToCartServise addToCartServise = new AddToCartServise();
            //addToCartServise.AddToCartList(_user, CreateShopItemService.Item);

            //CheckShopItemService check = new CheckShopItemService();
            //check.ShowContent(currentUser);

            DisplayCartService displayCartService = new DisplayCartService();

            
                displayCartService.ShowContent(currentUser);
            
        }
    }
}
