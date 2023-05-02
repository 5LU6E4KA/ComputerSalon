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
            var currents = ComputerSalonDB.Context.Assembling.ToList().Select(x => new
            {
                Name = x.Name,
                Quantity = x.CharacteristicsForPC.Quantity,
                Photo = x.Photo,
                Price = x.CharacteristicsForPC.Price + x.Monitors.Price
            }).ToList();
            ListProducts.ItemsSource = currents;
            Filter.SelectedIndex = 0;
        }

        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            TextBoxSearch.Text = "";
            Filter.SelectedIndex = 0;
        }

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAssembly();
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAssembly();
        }

        private void UpdateAssembly()
        {
            var currents = ComputerSalonDB.Context.Assembling.ToList().Select(x => new
            {
                Name = x.Name,
                Quantity = x.CharacteristicsForPC.Quantity,
                Photo = x.Photo,
                Price = x.CharacteristicsForPC.Price + x.Monitors.Price
            }).ToList();

            currents = currents.Where(x => x.Name.ToLower().Contains(TextBoxSearch.Text.ToLower())).ToList();

            if (Filter.SelectedIndex == 0)
                ListProducts.ItemsSource = currents.OrderBy(x => x.Name).ToList();
            else ListProducts.ItemsSource = currents.OrderByDescending(x => x.Name).ToList();

        }
    }
}
