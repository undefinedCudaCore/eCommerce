using eCommerce.Data;
using eCommerce.Models.ShopItem;
using eCommerce.Models.UserModels;
using eCommerce.Service.Contracts;
using eCommerce.Service.UserServices;
using Newtonsoft.Json;

namespace eCommerce.Service.ShopService.CartService
{
    internal class BuyItemService : IFileWrite, IShowContent, IFileCheckUserItems
    {
        private double _totalPrice;
        private bool _haveItems = false;
        private bool _notLowBalance = true;

        public void WriteToFile(Dictionary<string, Item> obj)
        {
            try
            {
                //File.Delete(FilePathData.CartDataPath);
                //File.Create(FilePathData.CartDataPath);

                var jsonData = JsonConvert.SerializeObject(obj);
                File.WriteAllText(FilePathData.CartDataPath2, jsonData);
                File.Replace(FilePathData.CartDataPath2, FilePathData.CartDataPath1, FilePathData.CartDataPath3);
                File.WriteAllText(FilePathData.CartDataPath1, jsonData);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Your list is empty.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("File directory was not found.");
            }
            catch (Exception)
            {
                Console.WriteLine("Other important error..Contact the developer.");
            }
        }

        public bool CheckIsThereItemsInCartForCurrentUser(User currentUser, Dictionary<string, Item> cartList, out bool haveItems)
        {
            haveItems = false;
            foreach (var item in cartList)
            {
                if (item.Value.ItemUserId == currentUser.UserId)
                {
                    Total(item.Value.ItemPrice);
                    haveItems = true;
                }
            }
            return false;
        }

        public double Total(double price)
        {
            if (price.Equals(double.NaN))
            {
                return 0;
            }
            _totalPrice += price;
            _totalPrice = Math.Round(_totalPrice, 2);
            return _totalPrice;
        }

        public bool CachOutQty(User user, Dictionary<string, Item> cartIems)
        {
            ReadFromFileService readFromFileService = new ReadFromFileService();
            var shopItems = readFromFileService.ReadFromFile(FilePathData.ShopItemDataPath);

            foreach (var shopItem in shopItems)
            {
                foreach (var cartItem in cartIems)
                {
                    if (cartItem.Value.ItemQuantity > shopItem.Value.ItemQuantity)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void BuyCartItems(User user)
        {
            ReadFromFileService readFromFile = new ReadFromFileService();
            var cartItemList = readFromFile.ReadFromFile(FilePathData.CartDataPath1);

            CheckIsThereItemsInCartForCurrentUser(user, cartItemList, out bool haveItems);
            _haveItems = haveItems;

            var itemInWarehouse = CachOutQty(user, cartItemList);

            if (haveItems && user.Balance < _totalPrice)
            {
                user.Balance = user.Balance;
                _notLowBalance = false;
            }
            else if (haveItems && !double.IsNaN(_totalPrice) && _totalPrice >= 0
                || haveItems && !double.IsNaN(user.Balance) && user.Balance >= 0
                || haveItems && _totalPrice <= user.Balance)
            {
                user.Balance = Math.Round(user.Balance - _totalPrice, 2);

                foreach (var item in cartItemList)
                {
                    if (item.Value.ItemUserId == user.UserId)
                    {
                        cartItemList.Remove(item.Key);
                    }
                }
                WriteToFile(cartItemList);
            }

            UsersDatabaseService database = new UsersDatabaseService();
            database.UpdateDatabase(user);
        }

        public void ShowContent(User currentUser)
        {
            Console.WriteLine($"Users  cart information:");
            Console.WriteLine("Cart items:");
            Console.WriteLine();

            if (_haveItems && _notLowBalance)
            {
                Console.WriteLine($"{currentUser.Username}, you bought your items successfully!!!");
            }
            else if (!DisplayCartService.cartEmpty)
            {
                Console.WriteLine("Purchase vas not successfull.");
            }
        }
    }
}
