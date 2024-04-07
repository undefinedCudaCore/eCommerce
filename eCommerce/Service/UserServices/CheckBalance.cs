using eCommerce.Models.UserModels;

namespace eCommerce.Service
{
    public class CheckBalanse
    {


        public static void CheckBalanceNow(User User)
        {
            // Check which user is logged in and insert to method

            // Change method input stuff 
            string temp = "Alma";


            //string temp = "Alma";
            //foreach (User user in User)
            //{
            //if (temp == user.Name)
            //{
            Console.WriteLine(User.Username);
            Console.WriteLine(User.Balance);

            //}
            //}

        }

    }
}