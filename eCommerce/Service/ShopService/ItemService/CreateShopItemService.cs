using eCommerce.Data;
using eCommerce.Models.ShopItem;
using eCommerce.Service.Contracts;
using Newtonsoft.Json;

namespace eCommerce.Service.ShopService.ItemService
{
    internal class CreateShopItemService : IFileRead
    {
        public Dictionary<string, Item> ReadFromFile()
        {
            if (File.Exists(FilePathData.ShopItemDataPath))
            {
                var jsonData = JsonConvert.DeserializeObject<Dictionary<string, Item>>(File.ReadAllText(FilePathData.ShopItemDataPath));
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

            File.WriteAllText(FilePathData.ShopItemDataPath, jsonData);
        }

        private static void AddShopItemToList(Item item)
        {
            CreateShopItemService createShopItemService = new CreateShopItemService();
            Dictionary<string, Item> itemDictionary = createShopItemService.ReadFromFile();

            if (itemDictionary == null)
            {
                itemDictionary = new Dictionary<string, Item>();
            }

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
