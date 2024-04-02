using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
        public User()
        {
            Name = string.Empty;
            Password = string.Empty;
            Balance = 0;
        }
        public User(string name, string password, double balance)
        {
            Name = name;
            Password = password;
            Balance = balance;
        }
    }
}