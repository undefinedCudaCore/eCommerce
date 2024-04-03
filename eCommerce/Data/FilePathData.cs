namespace eCommerce.Data
{
    internal class FilePathData
    {
        internal static string CartDataPath = new DirectoryInfo(Environment.CurrentDirectory) + "\\Data\\cartData.json";
        internal static string ShopItemDataPath = new DirectoryInfo(Environment.CurrentDirectory) + "\\Data\\shopItemData.json";
    }
}
