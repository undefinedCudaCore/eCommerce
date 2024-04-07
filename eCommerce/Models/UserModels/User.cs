using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Service.UserServices;

namespace eCommerce.Models.UserModels
{
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        //public string Password { get; set; }
        public double Balance { set; get; }




        public int UserId { get; set; } = 0;


        public eUserType UserType { get; set; } = eUserType.UNDEFINED;


        public User()

        {

        }

        public User(int UserId, eUserType UserType, string Username)
        {
            this.Username = Username;
            this.UserId = UserId;
            this.UserType = UserType;
        }

        public User(string name, string password, double balance)
        {
            Name = name;
            // Balance = balance;
        }


    }
}