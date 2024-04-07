using eCommerce.Data;
using eCommerce.Models.ShopItem;
using eCommerce.Service.Contracts;
using eCommerce.Service.RandomGenerators;
using Newtonsoft.Json;

namespace eCommerce.Service.ShopService.ItemService
{
    internal class CreateShopItemService : IFileRead, IFileWrite
    {
        internal static Item Item { get; set; }
        public Dictionary<string, Item> ReadFromFile()
        {
            if (File.Exists(FilePathData.ShopItemDataPath) && new FileInfo(FilePathData.ShopItemDataPath).Length > 0)
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

            itemDictionary.Add(RandomId.RandomIdGenerator(), item);

            WriteToFile(itemDictionary);
        }

        internal void CreateItem(string itemId, string itemName, string itemDescription, string itemType, double itemPrice)
        {
            Item = new Item(itemId, itemName, itemDescription, itemType, itemPrice);
            AddShopItemToList(Item);
        }
    }
}
