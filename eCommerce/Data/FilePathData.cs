namespace eCommerce.Data
{
    internal class FilePathData
    {
        internal static string CartDataPath1 = new DirectoryInfo(Environment.CurrentDirectory) + "\\Data\\cartData.json";
        internal static string CartDataPath2 = new DirectoryInfo(Environment.CurrentDirectory) + "\\Data\\cartDataTemp.json";
        internal static string CartDataPath3 = new DirectoryInfo(Environment.CurrentDirectory) + "\\Data\\cartDataBackUp.json";
        internal static string ShopItemDataPath = new DirectoryInfo(Environment.CurrentDirectory) + "\\Data\\shopItemData.json";
    }
}
