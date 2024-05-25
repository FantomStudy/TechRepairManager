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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF.JSON;

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        private void toLoginBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window win in Application.Current.Windows)
            {
                if (win.Name == "loginWindow")
                {
                    win.Width = this.Width;
                    win.Height = this.Height;
                    win.Left= this.Left;
                    win.Top = this.Top;
                    if (this.WindowState == WindowState.Maximized)
                    {
                        win.Left = 0;
                        win.Top = 0;
                    }
                    win.Show();
                }
                this.Close();
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (regUserName.Text != "" && regUserPassword.Password != "")
            {
                Serialize.Registration(regUserName, regUserPassword);
            }
        }
    }
}
