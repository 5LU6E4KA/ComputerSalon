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
    /// Логика взаимодействия для PageForBuyer.xaml
    /// </summary>
    public partial class PageForBuyer : Page
    {
        public PageForBuyer()
        {
            InitializeComponent();
        }

        private void Videocard_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Videocards());
        }

        private void Processors_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Processors());
        }

        private void Cases_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Cases());
        }
    }
}
