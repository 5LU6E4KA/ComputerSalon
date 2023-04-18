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
    /// Логика взаимодействия для Cases.xaml
    /// </summary>
    public partial class Cases : Page
    {
        public Cases()
        {
            InitializeComponent();
            DataGridCases.ItemsSource = ComputerSalonDB.Context.Cases.ToList().Select(x => new
            {
                Model = x.Model,
                FormFactor = x.FormFactor,
                PlacementPowerUnit = x.PlacementPowerUnit
            }).ToList();
        }
        
    }
}
