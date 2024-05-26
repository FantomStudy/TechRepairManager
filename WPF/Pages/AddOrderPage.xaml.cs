using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using WPF.Entities;
using WPF.Entity;
using WPF.JSON;
using static WPF.Login;

namespace WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        public AddOrderPage()
        {
            InitializeComponent();
            Serialize.DisplayCombobox(comboboxServices);
        }
        private void addServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            if (problemBox.Text != "" && comboboxServices.Text != "")
            {
                Serialize.AddRequest(MainWindow.CurrentUserName, problemBox, comboboxServices);
            }   
        }
    }
}
