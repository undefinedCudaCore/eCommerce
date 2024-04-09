using eCommerce.Data;
using eCommerce.Service.ShopService;

namespace eCommerce.Extentions
{
    internal static class GetItemIdToAddItemToCartExtention
    {
        internal static string GetItemIdToAddItemToCart()
        {
            ReadFromFileService readFromFileService = new ReadFromFileService();
            var itemDic = readFromFileService.ReadFromFile(FilePathData.ShopItemDataPath);
            var result = Console.ReadLine();

            if (String.IsNullOrEmpty(result))
            {
                return "false";
            }

            return result;
        }
    }
}
