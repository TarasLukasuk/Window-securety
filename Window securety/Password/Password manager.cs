
namespace Window_securety.Password
{
    class Password_manager
    {
        public Password_manager(string text)
        {
            User_password user_Password = new User_password(text);
            Secret_password secret_Password = new Secret_password(text);
        }

       public static bool User_password { get; set; }

       public static bool Secret_password { get; set; }
    }
}
