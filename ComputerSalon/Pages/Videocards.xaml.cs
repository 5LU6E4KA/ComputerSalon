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
    /// Логика взаимодействия для Videocards.xaml
    /// </summary>
    public partial class Videocards : Page
    {
        public Videocards()
        {
            InitializeComponent();
            DataGridVideocards.ItemsSource = ComputerSalonDB.Context.Videocards.ToList().Select(x => new
            {
                VideoMemoryCapacity = x.VideoMemoryCapacity,
                MemoryType = x.MemoryType,
                GraphicsProcessor = x.GraphicsProcessor
            }).ToList();
        }
        
    }
}
