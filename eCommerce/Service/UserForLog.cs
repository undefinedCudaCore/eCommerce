namespace eCommerce.Models.UserModels
{

    //RegistrationService _service = new RegistrationService();

    //_service.Register("Karolis", "Norvaisa");

    //        if (_service.Login("Karolis", "Norvaisa", out UInt32 _userId, out eUserType _userType))
    //        {
    //            Console.WriteLine(_userId);
    //            Console.WriteLine(Enum.GetName(typeof (eUserType),_userType));
    //        }


    public enum eUserType
    {
        UNDEFINED,
        CUSTOMER,
        MANAGER,
        ADMINISTRATOR
    }


    internal class UserForLog
    {


        public string Salt { get; set; }
        public string HashedPassword { get; set; }
        public int UserID { get; set; }
        public eUserType UserType { get; set; } = eUserType.CUSTOMER;


    }
}
