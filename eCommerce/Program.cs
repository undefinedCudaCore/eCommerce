﻿using eCommerce.Service;


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



                CheckBalanse.CheckBalanceNow(list);
                AppendBalance.AddToBalance(list);
                CheckBalanse.CheckBalanceNow(list);

            }

            //CreateShopItemService.CreateItem("1", "iPhone", "Not very good phone.", "Smartphone", 999.99);
        }
    }
}
