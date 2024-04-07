using eCommerce.Data;
using eCommerce.Models.ShopItem;
using eCommerce.Service.Contracts;
using Newtonsoft.Json;

namespace eCommerce.Service.ShopService.ItemService
{
    internal class CreateShopItemService : IFileRead, IFileWrite
    {
        internal static Item Item { get; set; }
        public Dictionary<string, Item> ReadFromFile()
        {
            if (File.Exists(FilePathData.ShopItemDataPath))
            {
                var jsonData = JsonConvert.DeserializeObject<Dictionary<string, Item>>(File.ReadAllText(FilePathData.ShopItemDataPath));
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
            else
            {
                return new Dictionary<string, Item>();
            }
        }

        public void WriteToFile(Dictionary<string, Item> item)
        {
            var jsonData = JsonConvert.SerializeObject(item);

            File.WriteAllText(FilePathData.ShopItemDataPath, jsonData);
        }

        private void AddShopItemToList(Item item)
        {
            Dictionary<string, Item> itemDictionary = ReadFromFile();

            if (itemDictionary == null)
            {
                itemDictionary = new Dictionary<string, Item>();
            }

            itemDictionary.Add(RandomId(), item);

            WriteToFile(itemDictionary);
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

        internal void CreateItem(string itemId, string itemName, string itemDescription, string itemType, double itemPrice)
        {
            Item = new Item(itemId, itemName, itemDescription, itemType, itemPrice);
            AddShopItemToList(Item);
        }
    }
}
