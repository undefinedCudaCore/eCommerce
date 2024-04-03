
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

            

            // Testing Code
            string temp = "Alma";
            var tempuser = User.Where(u => u.Name == temp).Select(u => u.Balance).ToList();
            // Testing code

            foreach (User user in User)
            {
                if (temp == user.Name)
                {
                    Console.WriteLine(user.Balance);

                }
            }

        }

    }
}