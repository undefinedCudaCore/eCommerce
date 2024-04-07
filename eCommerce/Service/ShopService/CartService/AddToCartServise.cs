using eCommerce.Data;
using eCommerce.Models.ShopItem;
using eCommerce.Models.UserModels;
using eCommerce.Service.Contracts;
using Newtonsoft.Json;

namespace eCommerce.Service.ShopService.CartService
{
    internal class AddToCartServise : IFileRead, IFileWrite
    {
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
                Console.WriteLine("Your list is null.");
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

        internal void AddToCartList(User user, Item item)
        {
            Dictionary<string, Item> cartDictionary = ReadFromFile();

            if (cartDictionary == null)
            {
                cartDictionary = new Dictionary<string, Item>();
            }

            cartDictionary.Add(user.UserId.ToString(), item);

            WriteToFile(cartDictionary);
        }
    }
}
