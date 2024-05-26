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
using TechLibrary;
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
        }
        public static string CurrentUserName { get; private set; }
        private void OnUserData(object sender, UserEventArgs e)
        {
            Users currentUser = e.User;
            CurrentUserName = currentUser.UserName;
            userNameTextBlock.Text += CurrentUserName;
            bool isAdmin = false;
            if (CurrentUserName.Contains("admin"))
            {
                isAdmin = true;
            }
            if (isAdmin)
            {
                adminServiceBtn.Visibility = Visibility.Visible;
                adminRequestBtn.Visibility = Visibility.Visible;
                userOrderBtn.Visibility = Visibility.Hidden;
                requestBtn.Visibility = Visibility.Hidden;
            }
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

        //For Admins
        private void NavigateToAdminService(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AdminPage());
        }
        private void NavigateToApplications(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Requests());
        }

        //For grag
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}