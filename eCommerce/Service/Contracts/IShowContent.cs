﻿using eCommerce.Models.UserModels;

namespace eCommerce.Service.Contracts
{
    internal interface IShowContent
    {
        public void ShowContent(User currentUser);
    }
}
