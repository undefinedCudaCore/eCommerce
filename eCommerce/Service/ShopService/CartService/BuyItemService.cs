using eCommerce.Data;
using eCommerce.Models.ShopItem;
using eCommerce.Models.UserModels;
using eCommerce.Service.Contracts;
using Newtonsoft.Json;

namespace eCommerce.Service.ShopService.CartService
{
    internal class BuyItemService : IFileRead, IFileWrite, IShowContent, IFileCheckUserItems
    {
        private double _price;
        public Dictionary<string, Item> ReadFromFile()
        {
            if (File.Exists(FilePathData.CartDataPath))
            {
                try
                {
                    var jsonData = JsonConvert.DeserializeObject<Dictionary<string, Item>>(File.ReadAllText(FilePathData.CartDataPath));
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
            }
        }

        public void WriteToFile(Dictionary<string, Item> obj)
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(obj);

                File.WriteAllText(FilePathData.CartDataPath, jsonData);
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

        public bool CheckIsThereItemsInCartForCurrentUser(User currentUser, Dictionary<string, Item> cartList)
        {
            foreach (var item in cartList)
            {
                if (item.Value.ItemUserId == currentUser.UserId)
                {
                    Total(item.Value.ItemPrice);
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
            return _price += price;
        }

        public void ShowContent(User currentUser)
        {
            Console.WriteLine($"Users  cart information:");
            Console.WriteLine("Cart items:");
            Console.WriteLine();

            Console.WriteLine($"{currentUser.Username}, you bought your items successfully!!!");
        }
    }
}
