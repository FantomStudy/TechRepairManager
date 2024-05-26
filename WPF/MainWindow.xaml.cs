using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.Entity;
using WPF.JSON;
using WPF.Pages;
using static WPF.Login;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Login loginWindow = Application.Current.Windows.OfType<Login>().FirstOrDefault();
            if (loginWindow != null)
            {
                loginWindow.UserData += OnUserData;
            }

            //if (.Contains("admin"))
            //{
            //    Button _adminButton = FindName("addServiceBtn") as Button;
            //    _adminButton.Visibility = Visibility.Visible;
            //}
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void OnUserData(object sender, UserEventArgs e)
        {
            Users user = e.User;
        }
        private void NavigateToUserOrder(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UserOrderPage());
        }

        private void NavigateToOrder(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddOrderPage());
        }

        private void NavigateToServices(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ServiceListPage());
        }

        private void NavigateToAbout(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AboutUsPage());
        }

        private void NavigateToAdminService(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddServicePage());
        }
    }
}