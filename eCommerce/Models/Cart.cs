using eCommerce.Models.ShopItem;

namespace eCommerce.Models
{
    internal class Cart
    {
        public Cart()
        {
            CartItemList = new Dictionary<string, Item>();
        }

        private int _cartId { get; set; }
        public Dictionary<string, Item> CartItemList { get; set; }

        // To diplay in cart:
        //Item -> Price -> Qty -> Total price
        //Check, if car have few same item - collapse and append quantity
    }
}
