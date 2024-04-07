namespace eCommerce.Models.UserModels
{
    public class UserManagementErrors()
    {
        internal bool success = false;
        internal bool UserNotExits = false;
        internal string Message { get; set; } = "";
    }
}
