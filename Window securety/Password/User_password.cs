
namespace Window_securety.Password
{
    class User_password : Password
    {
        public User_password(string text)
        {
            Get_password(text);
        }
        protected override void Get_password(string text)
        {
            string Received_password =null;

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\windows securety"))
            {
                if (key != null)
                {
                    if (key.GetValue("Password") !=null)
                    {
                        Received_password= key.GetValue("Password").ToString();
                    }
                    
                }

                if (Received_password == text)
                {
                    Password_manager.User_password = true;
                }
       }    }
    }
}
