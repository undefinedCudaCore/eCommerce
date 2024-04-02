
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service
{
    public class CheckBalanse
    {


        public static void CheckBalanceNow(List<User> User)
        {
            // Check which user is logged in and insert to method

            // Change method input stuff 

            //push attempt = 3




            Console.WriteLine("in name");
            string inp = "Alma";
            foreach (User user in User)
            {
                if (inp == user.Name)
                {
                    Console.WriteLine(user.Balance);
                }
            }

        }

    }
}