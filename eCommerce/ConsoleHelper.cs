using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce
{
    internal class ConsoleHelper
    {

        internal int GetUserInputNumeric(string message, int min, int max)
        {
            Console.WriteLine(message);
            int selection = -1;
            string userInput;
            bool isFirstTry = true;
            do
            {
                if (!isFirstTry)
                {
                    Console.WriteLine($"Wrong ! Entered a suitable pick available [{min} - {max - 1}]");
                }
                isFirstTry = false;
                userInput = Console.ReadLine();

            } while (!int.TryParse(userInput, out selection) || !((selection >= min) && (selection <= max - 1)));

            return selection;
        }

        internal string GetUserInputString(string message)
        {
            string userInput = "";
            bool isFirstTry = true;
            Console.WriteLine(message);
            do
            {
                if (!isFirstTry)
                {
                    Console.WriteLine($"Wrong ! Entered suitable Name/Surname");
                }
                isFirstTry = false;
                userInput = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    if (userInput[0] == 'q' || userInput[0] == 'Q')


                        break;
                }
            } while (string.IsNullOrWhiteSpace(userInput));
            return userInput;
        }
    }
}
