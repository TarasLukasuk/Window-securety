using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows;

namespace Window_securety
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Run();
            this.Show();

            _ = new Disabling_special_systems.Disabling_special_systems(1);

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\windows securety"))
            {
                if (key == null)
                {
                    Settings_window settings_Window = new Settings_window();
                    settings_Window.Show();
                }
            }

            try
            {
                User_image.Source = new BitmapImage(new Uri(File_path));
            }
            catch (Exception)
            {

            }
        }

        private void Log_in_Click(object sender, RoutedEventArgs e)
        {
            string text = string.Empty;

            text = Password.Password;

            Password_manager password_Manager = new Password_manager(text);

            text = Text.Text;

            password_Manager = new Password_manager(text);

            if (Password_manager.User_password || Password_manager.Secret_password == true)
            {
                _ = new Disabling_special_systems.Disabling_special_systems(0);
                Close();
            }
        }

        private OpenFileDialog openFileDialog = new OpenFileDialog();

        private void Open_picture_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog.Filter = "Images|*.jpg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                User_image.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private string File_path = $"C:\\Users\\{Environment.UserName}\\Documents\\windows securety\\Using_imag.jpg";
        private string Directory_path = $"C:\\Users\\{Environment.UserName}\\Documents\\windows securety";

        private void Save_picture_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Drawing.Image image = new Bitmap(openFileDialog.FileName);

                if (Directory.Exists(Directory_path) == false)
                {
                    Directory.CreateDirectory(Directory_path);
                }

                if (File.Exists(File_path) == false)
                {
                    image.Save(File_path);

                }
                else { image.Save(File_path); }
            }
            catch (Exception)
            {
                MessageBox.Show("Пробачте я не розумію яку картинку зберегти можливо ви не обрали картинку спочатку оберіть картинку та відкрийте",
                "Open picture",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
            }
        }

        private void Visualize_password_Click(object sender, RoutedEventArgs e)
        {
            if (Password.Visibility == Visibility.Visible)
            {
                Text.Text = Password.Password;
                Password.Visibility = Visibility.Hidden;
                Image.Source = new BitmapImage(new Uri(@"\Resours\Resours imag\eye.png", UriKind.Relative));
            }
            else
            {
                Password.Password = Text.Text;
                Password.Visibility = Visibility.Visible;
                Image.Source = new BitmapImage(new Uri(@"\Resours\Resours imag\Бrfdd.png", UriKind.Relative));
            }
        }


        private void Run()
        {
            string Path_run = Assembly.GetExecutingAssembly().Location;

            string path = Path_run.Replace("dll", "exe");
            string _path =  path;

            using (RegistryKey key=Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run"))
            {
                key.SetValue("Window securety", _path);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                Log_in_Click(sender, null);
            }
        }
    }
}
