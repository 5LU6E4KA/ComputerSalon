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
using ComputerSalon.Pages;

namespace ComputerSalon.Pages
{
    /// <summary>
    /// Логика взаимодействия для BuyersAuthorization.xaml
    /// </summary>
    public partial class BuyersAuthorization : Page
    {
        public BuyersAuthorization()
        {
            InitializeComponent();
        }

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }

        private void InputClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }
    }
}
