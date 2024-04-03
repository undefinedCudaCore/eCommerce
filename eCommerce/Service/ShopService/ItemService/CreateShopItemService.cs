using eCommerce.Models.ShopItem;
using Newtonsoft.Json;

namespace eCommerce.Service.ShopService.ItemService
{
    internal class CreateShopItemService
    {
        private static readonly string ItemFilePath = new DirectoryInfo(Environment.CurrentDirectory) + "\\Data\\shopItemData.json";

        internal Dictionary<string, Item> ReadShopItemsFromFile()
        {
            if (File.Exists(ItemFilePath))
            {
                var jsonData = JsonConvert.DeserializeObject<Dictionary<string, Item>>(File.ReadAllText(ItemFilePath));
                return jsonData;
            }
            else
            {
                return new Dictionary<string, Item>();
            }
        }

        internal void AddShopItemsToFile(Dictionary<string, Item> item)
        {
            var jsonData = JsonConvert.SerializeObject(item);

            File.WriteAllText(ItemFilePath, jsonData);
        }

        private static void AddShopItemToList(Item item)
        {
            CreateShopItemService createShopItemService = new CreateShopItemService();
            Dictionary<string, Item> itemDictionary = createShopItemService.ReadShopItemsFromFile();

            itemDictionary.Add(RandomId(), item);
            createShopItemService.AddShopItemsToFile(itemDictionary);
        }

        private static string RandomId()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var randomId = new String(stringChars);

            return randomId;
        }

        internal static void CreateItem(string itemId, string itemName, string itemDescription, string itemType, double itemPrice)
        {
            Item item = new Item(itemId, itemName, itemDescription, itemType, itemPrice);
            AddShopItemToList(item);
        }
    }
}
