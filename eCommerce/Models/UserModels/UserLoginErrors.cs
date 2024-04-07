namespace eCommerce.Models.UserModels
{
    public class UserLoginErrors()
    {
        internal bool success = false;
        internal bool UserNotExits = false;
        internal DateTime UserBlockedUntil = DateTime.Now;
        internal bool PasswordIncorrect = false;
        internal int TriesLeft = 0;
        internal string Message { get; set; } = "";
    }

    public class UserManagementErrors()
    {
        internal bool success = false;
        internal bool UserNotExits = false;
        internal string Message { get; set; } = "";
    }
}
