using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service
{
    public class AppendBalance
    {
        public static List<User> AddToBalance(List<User> list)
        {
            Console.WriteLine("How much Should be added to the balance?");
            double temp = 13.56;
            //double temp = double.Parse(Console.ReadLine());

            string name = "Alma";

            foreach (User user in list)
            {
                if (user.Name == name)
                {
                    user.Balance += temp;
                }
            }
            return list;
        }
    }
}
