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

namespace ComputerSalon.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChoosingRole.xaml
    /// </summary>
    public partial class ChoosingRole : Page
    {
        public ChoosingRole()
        {
            InitializeComponent();
        }

        private void BuyerButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BuyersAuthorization());
        }
        private void EmploeeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmploeesAuthorization());
        }

    }
}
