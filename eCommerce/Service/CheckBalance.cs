
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service
{
    public class CheckBalanse
    {


        public static void CheckBalanceNow(User user)
        {
            Console.WriteLine(user.Balance);
        }

    }
}