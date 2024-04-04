using eCommerce.Models.ShopItem;

namespace eCommerce.Service.Contracts
{
    internal interface IFileWrite
    {
        internal void WriteToFile(Dictionary<string, Item> obj);
    }
}
