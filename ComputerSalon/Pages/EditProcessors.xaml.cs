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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComputerSalon.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditProcessors.xaml
    /// </summary>
    public partial class EditProcessors : Page
    {
        private ComputerSalon.Entities.Processors _processors = new Entities.Processors();

        public EditProcessors(Processors selectedProcessors)
        {
            InitializeComponent();
            if(selectedProcessors != null) 
            {
                _processors = selectedProcessors;
            }
            DataContext = _processors;
        }
        private void SaveChanges()
        {
            StringBuilder error = new StringBuilder();
            if (String.IsNullOrEmpty(_processors.Model)) error.AppendLine("Укажите модель!");
            if (String.IsNullOrEmpty(_processors.CountOfCores.ToString())) error.AppendLine("Укажите количество ядер!");
            if (String.IsNullOrEmpty(_processors.Socket)) error.AppendLine("Укажите количество сокет!");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }

            if (_processors.ProcessorId == 0)
            {
                ComputerSalonDB.Context.Processors.Add(_processors);
            }

            ComputerSalonDB.Context.SaveChanges();
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveChanges();
                MessageBox.Show("Данные сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
