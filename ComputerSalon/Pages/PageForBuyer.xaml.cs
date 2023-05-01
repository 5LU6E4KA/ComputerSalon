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
        }

       
    }
}
