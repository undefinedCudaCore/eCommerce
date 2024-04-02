using eCommerce.Service;

namespace eCommerce
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = new List<User>();
            list.Add(new User("Alma", "password", 20.4));
            list.Add(new User("Bob", "password", 75.2));

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item.Balance);
            //}

            CheckBalanse.CheckBalanceNow(list);

        }
    }
}
