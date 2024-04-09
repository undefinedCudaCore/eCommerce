using eCommerce.Service.RandomGenerators;

namespace eCommerce.Service.ShopService.ItemService
{
    internal static class CollectNewItemDataExtention
    {
        internal static void CollectNewItemData(CreateShopItemService newItem)
        {
            try
            {
                Console.WriteLine("Add item name:");
                string itemName = Console.ReadLine();

                Console.WriteLine("Add item description:");
                string itemDescription = Console.ReadLine();

                Console.WriteLine("Add item type:");
                string itemType = Console.ReadLine();

                Console.WriteLine("Add item price (decimal):");
                double itemPrice = double.Parse(Console.ReadLine());

                newItem.CreateItem(RandomId.RandomIdGenerator(), itemName, itemDescription, itemType, itemPrice);

                Console.WriteLine($"Item '{itemName}' was successfully added.");
                Thread.Sleep(3000);
                Console.Clear();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Null object given..");
                Thread.Sleep(3000);
                Console.Clear();
            }
            catch (FormatException)
            {
                Console.WriteLine("Entered wrong format.");
                Thread.Sleep(3000);
                Console.Clear();
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong, contact the system administrator....");
                Thread.Sleep(3000);
                Console.Clear();
            }
        }
    }
}
