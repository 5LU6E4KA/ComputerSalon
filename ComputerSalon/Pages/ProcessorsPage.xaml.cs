using ComputerSalon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
    public partial class ProcessorsPage : Page
    {
        public ProcessorsPage()
        {
            InitializeComponent();
            DataGridProcessors.ItemsSource = ComputerSalonDB.Context.Processors.ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.EditProcessors((sender as System.Windows.Controls.Button).DataContext as Processors));
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ComputerSalonDB.Context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DataGridProcessors.ItemsSource = ComputerSalonDB.Context.Processors.ToList();
            }
            var view = CollectionViewSource.GetDefaultView(DataGridProcessors.ItemsSource);
            view.Refresh();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.EditProcessors(null));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(System.Windows.MessageBox.Show($"Вы точно хотите удлить запись?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var selectedItems = DataGridProcessors.SelectedItems;
                if (selectedItems != null && selectedItems.Count > 0)
                {
                    foreach (var item in selectedItems.Cast<dynamic>().ToList())
                    {
                        ComputerSalonDB.Context.Processors.Remove(item);
                    }
                    ComputerSalonDB.Context.SaveChanges();
                    DataGridProcessors.ItemsSource = ComputerSalonDB.Context.Processors.ToList();
                }
            }
            
        }
    }
}
