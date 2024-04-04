using eCommerce.Service;
using eCommerce.Service.ShopService.CartService;
using eCommerce.Service.ShopService.ItemService;

namespace eCommerce
{
    public class Program
    {
        static void Main(string[] args)
        {


            var list = new List<User>();
            // list.Add(new User("Alma", "password", 20.4));
            // list.Add(new User("Bob", "password", 75.2));

            User _user;

            UserRegistration.Register("Karolis", "lala1", eUserType.ADMINISTRATOR);
            UserRegistration.Register("Karolis1", "lala1", eUserType.CUSTOMER);
            UserRegistration.Register("Karolis2", "lala2", eUserType.MANAGER);

            _user = UserLogin.Login("Karolis1", "lala1");

            _user.UpdateBalance(1000);

            _user = UserLogin.Login("Karolis2", "lala2");

            _user = UserLogin.Login("Karolis", "lala1");



            CheckBalanse.CheckBalanceNow(list);
            //AppendBalance.AddToBalance(list);
            CheckBalanse.CheckBalanceNow(list);


            CreateShopItemService createShopItemService = new CreateShopItemService();
            createShopItemService.CreateItem("1", "iPhone", "Not very good phone.", "Smartphone", 999.99);
            AddToCartServise addToCartServise = new AddToCartServise();
            addToCartServise.AddToCartList(_user, CreateShopItemService.Item);
        }
    }
}
