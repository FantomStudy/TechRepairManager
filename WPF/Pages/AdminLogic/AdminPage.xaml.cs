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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.JSON;

namespace WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddService.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            Serialize.DisplayCombobox(delComboboxRequest);
        }

        private void addServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            if (serviceName.Text != "" && serviceDescription.Text != "" && serviceCost.Text != "")
            {
                Serialize.AddService(serviceName, serviceDescription, serviceCost);
            }
        }

        private void delServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            if (delServiceName.Text != "")
            {
                Serialize.DeleteService(delServiceName);
            }
        }

        private void delRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            if (delRequestName.Text != "" && delComboboxRequest.Text != "")
            {
                Serialize.DeleteRequest(delRequestName, delComboboxRequest);
            }
        }
    }
}
