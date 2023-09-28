
namespace Window_securety
{
    /// <summary>
    /// Логика взаимодействия для Settings_window.xaml
    /// </summary>
    public partial class Settings_window : Window
    {
        public Settings_window()
        {
            InitializeComponent();
        }

        private void top_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = ((int)line.ActualWidth);
            doubleAnimation.Duration = TimeSpan.FromSeconds(0.2);
            line_anim.BeginAnimation(WidthProperty, doubleAnimation);

            text_titel.FontSize = 8;
            text_titel.Margin = new Thickness(0, 0, 0, 30);

            System.Windows.Media.Color color = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFDC12FF");
            text_titel.Foreground = new SolidColorBrush(color);
        }

        private void lower_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = ((int)line.ActualWidth);
            doubleAnimation.Duration = TimeSpan.FromSeconds(0.2);
            _line_anim.BeginAnimation(WidthProperty, doubleAnimation);

            _text_titel.FontSize = 8;
            _text_titel.Margin = new Thickness(0, 0, 0, 30);

            System.Windows.Media.Color color = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFDC12FF");
            _text_titel.Foreground = new SolidColorBrush(color);
        }

        private void Register_password_Click(object sender, RoutedEventArgs e)
        {
            if (Top_password.Text == lower_Password.Text)
            {
                using (RegistryKey Password_key = Registry.CurrentUser.CreateSubKey(@"Software\windows securety"))
                {
                    Password_key.SetValue("Password", Top_password.Text);
                    this.Close();
                }
            }
        }
    }

}
