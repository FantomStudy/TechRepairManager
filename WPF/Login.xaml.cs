using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF.JSON;
using static System.Net.Mime.MediaTypeNames;

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            this.Name = "loginWindow";
        }

        private void toRegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            Registration regWindow = new Registration();
            regWindow.Width = this.Width;
            regWindow.Height = this.Height;
            regWindow.Left = this.Left;
            regWindow.Top = this.Top;
            if (this.WindowState == WindowState.Maximized)
            {
                regWindow.Left = 0;
                regWindow.Top = 0;
            }
            regWindow.Show();
            this.Hide();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (logUserName.Text != "" && logUserPassword.Password != "")
            {
                if (Serialize.CheckUser(logUserName, logUserPassword))
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Width = this.Width;
                    mainWindow.Height = this.Height;
                    mainWindow.Left = this.Left;
                    mainWindow.Top = this.Top;
                    if (this.WindowState == WindowState.Maximized)
                    {
                        mainWindow.Left = 0;
                        mainWindow.Top = 0;
                    }
                    mainWindow.Show();
                    this.Hide();
                }
            }
        }
    }
}
