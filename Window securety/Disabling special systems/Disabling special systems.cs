
namespace Window_securety.Disabling_special_systems
{
    class Disabling_special_systems
    {
        public Disabling_special_systems(byte Value)
        {
            Disable_Task_Manager(Value);
            Disable_windows_button();
        }

        private void Disable_Task_Manager(byte value)
        {
            using (RegistryKey Disable_Task_Manager_Key = Registry.CurrentUser.CreateSubKey
                (@"Software\Microsoft\Windows\CurrentVersion\Policies\System"))
            {
                if (Disable_Task_Manager_Key != null)
                {
                    if (Disable_Task_Manager_Key.GetValue("DisableTaskMgr") != null)
                    {
                        Disable_Task_Manager_Key.SetValue("DisableTaskMgr", value,
                            RegistryValueKind.DWord);
                    }
                    else { Disable_Task_Manager_Key.SetValue("DisableTaskMgr", 1); }
                }
            }
        }

        private void Disable_windows_button()
        {
            using (RegistryKey Disable_windows_button_key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Keyboard Layout"))
            {
                if (Disable_windows_button_key!=null)
                {
                    if (Disable_windows_button_key.GetValue("Scancode Map") ==null)
                    {
                        MessageBox.Show("Для більшої безпеки відключіть кнопку windows " +
                            "так як це враховано вироиником ващої клавіатури",
                            "Disable windows button",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                }
            }
        }
    }
}
