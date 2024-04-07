using eCommerce.Data;
using eCommerce.Models.UserModels;
using eCommerce.Service.Contracts;

namespace eCommerce.Service.ShopService.ItemService
{
    internal class CheckShopItemService : IShowContent
    {

        public void ShowContent(User currentUser)
        {
            ReadFromFileService readFromFileService = new ReadFromFileService();
            var itemDictionary = readFromFileService.ReadFromFile(FilePathData.ShopItemDataPath);

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
