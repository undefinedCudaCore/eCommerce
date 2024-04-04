namespace eCommerce.Service
{
    public class CheckBalanse
    {


        public static void CheckBalanceNow(List<User> User)
        {
            // Check which user is logged in and insert to method

            // Change method input stuff 
            string temp = "Alma";


            //string temp = "Alma";
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