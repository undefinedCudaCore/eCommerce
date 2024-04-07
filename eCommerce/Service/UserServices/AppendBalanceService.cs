using eCommerce.Models.UserModels;
using eCommerce.Service.UserServices;

namespace eCommerce.Service
{
    public class AppendBalanceService
    {
        //public static List<User> AddToBalance(List<User> list)
        //{
        //    Console.WriteLine("How much Should be added to the balance?");
        //    double temp = 13.56;
        //    //double temp = double.Parse(Console.ReadLine());

        string name = "Alma";


        // Less Optimized Code Below????

        //foreach (User user in list)
        //{
        //    if (user.Name == name)
        //    {
        //        user.Balance += temp;
        //    }
        //}

        // 

        //var templist = list.Where(u => u.Name == name)
        //    .Select(u => new User { Name = u.Name,Password = u.Password,Balance = u.Balance + temp })
        //    .ToList(); 
        // return templist;
        public void UpdateBalance(User _user, double value)
        {
            _user.Balance += value;
            UsersDatabaseService database = new UsersDatabaseService();
            database.UpdateDatabase(_user);
        }


    }

}
