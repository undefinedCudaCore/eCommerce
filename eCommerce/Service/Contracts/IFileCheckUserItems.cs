﻿using eCommerce.Models.ShopItem;
using eCommerce.Models.UserModels;

namespace eCommerce.Service.Contracts
{
    internal interface IFileCheckUserItems
    {
        public bool CheckIsThereItemsInCartForCurrentUser(User currentUser, Dictionary<string, Item> cartList, out bool haveItems);

        public double Total(double price);
    }
}
