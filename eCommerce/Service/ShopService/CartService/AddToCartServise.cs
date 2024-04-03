using eCommerce.Data;
using eCommerce.Models.ShopItem;
using eCommerce.Service.Contracts;
using Newtonsoft.Json;

namespace eCommerce.Service.ShopService.CartService
{
    internal class AddToCartServise : IFileRead
    {
        public Dictionary<string, Item> ReadFromFile()
        {
            if (File.Exists(FilePathData.CartDataPath))
            {
                var jsonData = JsonConvert.DeserializeObject<Dictionary<string, Item>>(File.ReadAllText(FilePathData.CartDataPath));
                return jsonData;
            }
            else
            {
                return new Dictionary<string, Item>();
            }
        }
    }
}
