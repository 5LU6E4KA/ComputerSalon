using ComputerSalon.Pages;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using Path = System.IO.Path;

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
        private static bool DarkTheme;

        private void ResetTheme(object sender, RoutedEventArgs e)
        {
            Uri uri;
            if (DarkTheme)
                ChangeTheme("Light");
            else ChangeTheme("Dark");
        }

        private void ChangeTheme(string name)
        {
            Uri uri = new Uri(@"..\Resources\OwnerDictionary.xaml", UriKind.Relative);
            if (name == "Dark")
            {
                uri = new Uri(@"..\Resources\TeacherDictionary.xaml", UriKind.Relative);
            }
            DarkTheme = !(DarkTheme);
            ResourceDictionary resDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resDict);
            Config.Theme = name;
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
            else if (MainFrame.Content is PageForEmployee)
            {
                MainFrame.Navigate(new EmploeesAuthorization());
            }
        }

        private void ExportClick(object sender, RoutedEventArgs e)
        {
            ExportData(path);
        }

        private void ImportClick(object sender, RoutedEventArgs e)
        {
            ImportData();
        }

        // Получение пути каталога в компьютере и соединение пути с файлом
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "exportFile.txt");

        private void ExportData(string path)
        {
            StreamWriter streamWriter = new StreamWriter(path);

            using (var context = new Entities.Entities())
            {
                foreach (var element in context.Users)
                {
                    streamWriter.WriteLine($"{element.Surname} {element.Name} {element.Patronymic} {element.Email}");
                }
            }
            streamWriter.Close();
            Process.Start("notepad.exe", path);
        }

        private void ImportData()
        {
            OpenFileDialog dialogWindow = new OpenFileDialog();
            dialogWindow.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dialogWindow.ShowDialog();
            if (dialogWindow.FileName == "")
            {
                MessageBox.Show("Файл для импорта не выбран!");
            }
            else
            {
                string fileContent = File.ReadAllText(dialogWindow.FileName);
                MessageBox.Show(fileContent, "Содержимое файла");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ChangeTheme(Config.Theme);
            if (Config.Theme == "Light") DarkTheme = false;
            else DarkTheme = true;
        }
    }
}
