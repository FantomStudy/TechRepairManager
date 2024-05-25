using Newtonsoft.Json;
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
using WPF.JSON;
using WPF.Pages;

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
            DataContext = this;
            if (UserName.Contains("admin"))
            {
                Button _adminButton = FindName("adminServiceBtn") as Button;
                _adminButton.Visibility = Visibility.Visible;
            }
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public string UserName
        {
            get { return Serialize.UserName; }
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