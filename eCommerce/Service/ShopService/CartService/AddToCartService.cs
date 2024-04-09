using eCommerce.Data;
using eCommerce.Models.ShopItem;
using eCommerce.Models.UserModels;
using eCommerce.Service.Contracts;
using eCommerce.Service.RandomGenerators;
using Newtonsoft.Json;

namespace eCommerce.Service.ShopService.CartService
{
    internal class AddToCartService : IFileWrite
    {

        public void WriteToFile(Dictionary<string, Item> obj)
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(obj);

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

        internal void AddToCartList(User user, Item item)
        {
            ReadFromFileService readFromFileService = new ReadFromFileService();
            Dictionary<string, Item> cartDictionary = readFromFileService.ReadFromFile(FilePathData.CartDataPath1);

            if (cartDictionary == null)
            {
                cartDictionary = new Dictionary<string, Item>();
            }
            item.ItemUserId = user.UserId;
            item.ItemQuantity = 1;

            cartDictionary.Add(RandomId.RandomIdGenerator(), item);

            WriteToFile(cartDictionary);
        }
    }
}
