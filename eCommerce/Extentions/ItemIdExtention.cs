using eCommerce.Data;
using eCommerce.Models.ShopItem;
using eCommerce.Service.ShopService;

namespace eCommerce.Extentions
{
    internal static class ItemIdExtention
    {
        internal static string SetItemId()
        {
            ReadFromFileService readFromFileService = new ReadFromFileService();
            Dictionary<string, Item> shopItems = readFromFileService.ReadFromFile(FilePathData.ShopItemDataPath);
            string result = "";

            if (shopItems.Count >= 1)
            {
                result = (shopItems.Count + 1).ToString();
            }
            if (shopItems.Count == 0)
            {
                result = "1";
            }

            return result;
        }
    }
}
