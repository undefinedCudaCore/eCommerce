using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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



            //praleidzia neigiamus skaicius
            //reikia taisyt
            double temp = 0;
            while (!double.TryParse(Console.ReadLine(),out temp))
            {
                if (temp > 0)
                {
                    user.Balance += temp;
                }
                else
                {
                    Console.WriteLine("Incorrect input detected, Try again ");
                    Console.WriteLine("You should write a positive number.");
                }
            }

           


    


            //Temp Code To Check Balance After Adding
            Console.WriteLine(user.Balance);
            Console.WriteLine(user.Balance);
            Console.WriteLine(user.Balance);
            //Temp Code To Check Balance After Adding

            Console.WriteLine("Amount added to account");
        }
    }

}
