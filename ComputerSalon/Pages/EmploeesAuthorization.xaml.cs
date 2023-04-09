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
    /// Логика взаимодействия для EmploeesAuthorization.xaml
    /// </summary>
    public partial class EmploeesAuthorization : Page
    {
        public EmploeesAuthorization()
        {
            InitializeComponent();
        }

        private void InputClickForEmployee(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(LoginTBEmployee.Text) || String.IsNullOrEmpty(PasswordTBEmployee.Text) || String.IsNullOrEmpty(PersonalCodeTBEmployee.Text))
            {
                {
                    MessageBox.Show("Есть незаполненные поля", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                using (var database = new Entities.Entities())
                {
                    var employee = database.Employees.FirstOrDefault(x => x.PersonalCode == this.PersonalCodeTBEmployee.Text);

                    if (employee == null)
                    {
                        var result = MessageBox.Show("Сотрудник не найден!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Information);
                        if (result == MessageBoxResult.OK)
                        {
                            NavigationService.Navigate(new ChoosingRole());
                        }
                    }
                    else if (employee.Users.Email == LoginTBEmployee.Text && employee.Users.Password == PasswordTBEmployee.Text && employee.PersonalCode == PersonalCodeTBEmployee.Text)
                    {
                        NavigationService.Navigate(new PageForEmployee());
                    }
                }
            }
        }
    }
}
