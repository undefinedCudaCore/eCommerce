using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Models.UserModels;

namespace eCommerce.Service.UserServices
{
    internal class SecurityService
    {
        private static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NothingInteresting.json");

        public SecurityService()
        {
        }

        internal string GenerateSalt()
        {
            var bytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            return Convert.ToBase64String(bytes);
        }

        internal string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        internal Dictionary<string, UserForLog> LoadUsers()
        {
            if (!File.Exists(FilePath))
            {
                return new Dictionary<string, UserForLog>();
            }

            var json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<Dictionary<string, UserForLog>>(json);
        }

        internal void SaveUsers(Dictionary<string, UserForLog> users)
        {
            var json = JsonConvert.SerializeObject(users);
            File.WriteAllText(FilePath, json);
        }
    }
}
