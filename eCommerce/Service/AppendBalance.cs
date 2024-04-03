using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service
{
    public class AppendBalance
    {
        public static void Appendbalance(User user)
        {

            //Temp Code To Check Balance Before Adding
            Console.WriteLine(user.Balance);
            Console.WriteLine(user.Balance);
            Console.WriteLine(user.Balance);
            //Temp Code To Check Balance Before Adding

            Console.WriteLine("How much should we add to the current account??");
            Console.WriteLine("Enter The Amount:  ");
            double temp = int.Parse(Console.ReadLine());


            

            user.Balance += temp;

            //Temp Code To Check Balance After Adding
            Console.WriteLine(user.Balance);
            Console.WriteLine(user.Balance);
            Console.WriteLine(user.Balance);
            //Temp Code To Check Balance After Adding

            Console.WriteLine("Amount added to account");
        }
    }

}
