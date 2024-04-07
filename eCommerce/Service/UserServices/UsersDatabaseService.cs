using eCommerce.Models.UserModels;
using Newtonsoft.Json;

namespace eCommerce.Service.UserServices
{
    public class UsersDatabaseService
    {
        private Dictionary<int, User> userdata = new Dictionary<int, User>();
        private static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UsersDatabase.json");

        public UsersDatabaseService() { }

        public void AddUser(User user)
        {
            if (userdata != null)
            {
                if (!userdata.ContainsKey(user.UserId))
                {
                    userdata.Add(user.UserId, user);
                }
            }

            SaveDatabase(userdata);

        }
        public void UpdateDatabase(User _user)
        {
            userdata = LoadDatabase();

            if (userdata.ContainsKey(_user.UserId))
            {
                userdata[_user.UserId] = _user;
            }

            SaveDatabase(userdata);

        }

        public void RemoveUser(int userId)
        {
            if (userdata != null)
            {
                if (userdata.ContainsKey(userId))
                {
                    userdata.Remove(userId);
                }
            }
        }

        public User LoadUserData(User _user)
        {
            userdata = LoadDatabase();
            if (userdata.ContainsKey(_user.UserId))
            {
                return userdata[_user.UserId];
            }
            else
            {
                AddUser(_user);
                return _user;
            }
        }

        public Dictionary<int, User> LoadDatabase()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                userdata = JsonConvert.DeserializeObject<Dictionary<int, User>>(json);

                if (userdata == null)
                {

                }
                else return userdata;
            }
            else
            {
                File.Create(FilePath);
            }
            return new Dictionary<int, User>();

        }

        public void SaveDatabase(Dictionary<int, User> userdata)
        {
            string json = JsonConvert.SerializeObject(userdata);
            File.WriteAllText(FilePath, json);
        }
    }
}