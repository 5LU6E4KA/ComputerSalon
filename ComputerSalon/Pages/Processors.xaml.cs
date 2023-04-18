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
    /// Логика взаимодействия для Processors.xaml
    /// </summary>
    public partial class Processors : Page
    {
        public Processors()
        {
            InitializeComponent();
            DataGridProcessors.ItemsSource = ComputerSalonDB.Context.Processors.ToList().Select(x => new
            {
                Model = x.Model,
                Socket = x.Socket,
                CountOfCores = x.CountOfCores
            }).ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditProcessors());
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
