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

        internal void AddToCartList(User user, string itemId)
        {
            ReadFromFileService readFromFileService = new ReadFromFileService();
            Dictionary<string, Item> cartDictionary = readFromFileService.ReadFromFile(FilePathData.CartDataPath1);

            ReadFromFileService readFromFileService1 = new ReadFromFileService();
            var itemDic = readFromFileService.ReadFromFile(FilePathData.ShopItemDataPath);

            if (cartDictionary == null)
            {
                cartDictionary = new Dictionary<string, Item>();
            }

            foreach (var item in itemDic)
            {
                if (item.Value.ItemId == itemId)
                {
                    item.Value.ItemUserId = user.UserId;
                    item.Value.ItemQuantity = 1;

                    cartDictionary.Add(RandomId.RandomIdGenerator(), item.Value);
                }
            }

            WriteToFile(cartDictionary);
        }
    }
}
