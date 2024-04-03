using eCommerce.Models.ShopItem;

namespace eCommerce.Service.Contracts
{
    internal interface IFileRead
    {
        internal Dictionary<string, Item> ReadFromFile();
    }
}
