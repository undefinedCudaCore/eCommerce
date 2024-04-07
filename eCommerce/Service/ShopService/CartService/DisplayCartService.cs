using eCommerce.Data;
using eCommerce.Models.ShopItem;
using eCommerce.Models.UserModels;
using eCommerce.Service.Contracts;

namespace eCommerce.Service.ShopService.CartService
{
    internal class DisplayCartService : IShowContent, IFileCheckUserItems
    {
        private double _totalPrice;
        public static bool cartEmpty = false;

        public bool CheckIsThereItemsInCartForCurrentUser(User currentUser, Dictionary<string, Item> cartList, out bool haveItems)
        {
            haveItems = false;
            foreach (var item in cartList)
            {
                if (item.Value.ItemUserId == currentUser.UserId)
                {
                    haveItems = true;
                    return true;
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
            return _totalPrice += price;
        }

        public void ShowContent(User currentUser)
        {
            var currUserId = currentUser.UserId;

            ReadFromFileService readFromFileService = new ReadFromFileService();
            var cartDictionary = readFromFileService.ReadFromFile(FilePathData.CartDataPath1);
            bool isThereItems = CheckIsThereItemsInCartForCurrentUser(currentUser, cartDictionary, out bool haveItems);

            Console.WriteLine($"Users  cart information:");
            Console.WriteLine("Cart items:");
            Console.WriteLine();

            if (!isThereItems)
            {
                cartEmpty = true;
                Console.WriteLine("Cart is empty...");
            }
            else
            {
                foreach (var item in cartDictionary)
                {
                    if (item.Value.ItemUserId == currUserId)
                    {
                        Console.WriteLine("--------");
                        Console.WriteLine($"Title: {item.Value.ItemName}");
                        Console.WriteLine($"Type: {item.Value.ItemType}");
                        Console.WriteLine($"Price: {item.Value.ItemPrice}");
                        Console.WriteLine($"Qty: {item.Value.ItemQuantity}");
                        Console.WriteLine($"Decription: {item.Value.ItemDescription}");
                        Console.WriteLine("--------");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
