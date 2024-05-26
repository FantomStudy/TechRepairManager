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
    /// Логика взаимодействия для Applications.xaml
    /// </summary>
    public partial class Requests : Page
    {
        public Requests()
        {
            InitializeComponent();
            Serialize.DisplayRequest(applicationStackPanel);
        }
    }
}
