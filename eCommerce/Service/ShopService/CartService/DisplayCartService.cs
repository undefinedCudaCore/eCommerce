using eCommerce.Data;
using eCommerce.Models.ShopItem;
using eCommerce.Models.UserModels;
using eCommerce.Service.Contracts;
using Newtonsoft.Json;

namespace eCommerce.Service.ShopService.CartService
{
    internal class DisplayCartService : IFileRead, IShowContent, IFileCheckUserItems
    {
        private double _totalPrice;
        public static bool cartEmpty = false;

        public Dictionary<string, Item> ReadFromFile()
        {
            if (File.Exists(FilePathData.CartDataPath1))
            {
                try
                {
                    var jsonData = JsonConvert.DeserializeObject<Dictionary<string, Item>>(File.ReadAllText(FilePathData.CartDataPath1));

                    List<KeyValuePair<string, Item>> myList = jsonData.ToList();

                    myList.Sort(
                        delegate (KeyValuePair<string, Item> pair1,
                        KeyValuePair<string, Item> pair2)
                        {
                            return pair1.Value.ItemName.CompareTo(pair2.Value.ItemName);
                        }
                    );

                    return myList.ToDictionary<string, Item>();
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("File directory was not found.");
                    return new Dictionary<string, Item>();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File was not found");
                    return new Dictionary<string, Item>();
                }
                catch (Exception)
                {
                    Console.WriteLine("Other important error..Contact the developer.");
                    return new Dictionary<string, Item>();
                }
            }
            else
            {
                return new Dictionary<string, Item>();

                // throw new FileNotFoundException();
            }
        }

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
            var cartDictionary = ReadFromFile();
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
                        Console.WriteLine($"Decription: {item.Value.ItemDescription}");
                        Console.WriteLine("--------");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
