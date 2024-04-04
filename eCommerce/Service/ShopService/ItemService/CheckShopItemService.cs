using eCommerce.Data;
using eCommerce.Models.ShopItem;
using eCommerce.Service.Contracts;
using Newtonsoft.Json;

namespace eCommerce.Service.ShopService.ItemService
{
    internal class CheckShopItemService : IFileRead, IShowContent
    {
        public Dictionary<string, Item> ReadFromFile()
        {
            if (File.Exists(FilePathData.ShopItemDataPath))
            {
                try
                {
                    var jsonData = JsonConvert.DeserializeObject<Dictionary<string, Item>>(File.ReadAllText(FilePathData.ShopItemDataPath));
                    return jsonData;
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
                throw new FileNotFoundException();
            }
        }

        public void ShowContent(User currentUser)
        {
            var itemDictionary = ReadFromFile();

            try
            {
                Console.WriteLine($"Welcome to eCommerce Shop {currentUser.Username}!");
                Console.WriteLine("--------------------------");
                Console.WriteLine();

                Console.WriteLine("Here you can list our products:");
                Console.WriteLine();

                foreach (var item in itemDictionary)
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
            catch (IOException)
            {
                Console.WriteLine("Something went wrong, contact your software administrator.");
            }
        }
    }
}
