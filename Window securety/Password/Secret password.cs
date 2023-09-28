
namespace Window_securety.Password
{
    class Secret_password : Password
    {
        public Secret_password(string text)
        {
            Get_password(text);
        }

        protected override void Get_password(string text)
        {
           if (text == "Admin")
            {
                Password_manager.Secret_password = true;
            }
        }
    }
}
