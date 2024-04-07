namespace eCommerce.Models.ShopItem
{
    public class Item
    {
        public Item(string itemId, string itemName, string itemDescription, string itemType, double itemPrice)
        {
            ItemId = itemId;
            ItemName = itemName;
            ItemDescription = itemDescription;
            ItemType = itemType;
            ItemPrice = itemPrice;
        }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemType { get; set; }
        public double ItemPrice { get; set; }
        public int ItemQuantity { get; set; }
    }
}
