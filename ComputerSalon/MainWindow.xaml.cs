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
using System.ComponentModel;
using System.Windows.Markup;
using ComputerSalon.Pages;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace ComputerSalon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += WindowClosing;
            MainFrame.Content = new ChoosingRole();
        }
        private void WindowClosing(object sender, CancelEventArgs e)
        {
            const string message = "Закрыть приложение?";
            const string caption = "Form closing";
            var result = MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
        private static bool DarkTheme = false;

        private void ResetTheme(object sender, RoutedEventArgs e)
        {
            Uri uri;
            if (!DarkTheme)
                uri = new Uri(@"..\Resources\OwnerDictionary.xaml", UriKind.Relative);
            else uri = new Uri(@"..\Resources\TeacherDictionary.xaml", UriKind.Relative);
            DarkTheme = !(DarkTheme);
            ResourceDictionary resDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resDict);
        }

        private void ComeBack(object sender, RoutedEventArgs e)
        {

            if (MainFrame.Content is BuyersAuthorization)
            {
                MainFrame.Navigate(new ChoosingRole());
            }
            else if (MainFrame.Content is EmploeesAuthorization)
            {
                MainFrame.Navigate(new ChoosingRole());
            }
            else if (MainFrame.Content is Registration)
            {
                MainFrame.Navigate(new BuyersAuthorization());
            }
            else if (MainFrame.Content is PageForBuyer)
            {
                MainFrame.Navigate(new ChoosingRole());
            }
            else if(MainFrame.Content is PageForEmployee)
            {
                MainFrame.Navigate(new EmploeesAuthorization());
            }
        }

        private void ExportClick(object sender, RoutedEventArgs e)
        {

        }

        private void ImportClick(object sender, RoutedEventArgs e)
        {

        }

        private void ExportData()
        {
            string path = "exportFile.txt";
            StreamWriter streamWriter = new StreamWriter(path);
        }
    }
}
