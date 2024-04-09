namespace eCommerce.Data
{
    internal class FilePathData
    {
        internal static string CartDataPath1 = new DirectoryInfo(Environment.CurrentDirectory) + "\\cartData.json";
        internal static string CartDataPath2 = new DirectoryInfo(Environment.CurrentDirectory) + "\\cartDataTemp.json";
        internal static string CartDataPath3 = new DirectoryInfo(Environment.CurrentDirectory) + "\\cartDataBackUp.json";
        internal static string ShopItemDataPath = new DirectoryInfo(Environment.CurrentDirectory) + "\\shopItemData.json";
    }
}
