using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using ComputerSalon.Pages;



namespace ComputerSalon.Pages
{
    /// <summary>
    /// Логика взаимодействия для BuyersAuthorization.xaml
    /// </summary>
    public partial class BuyersAuthorization : Page
    {
        public BuyersAuthorization()
        {
            InitializeComponent();
        }

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }

        private void InputClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(LoginTB.Text) || String.IsNullOrEmpty(PasswordTB.Password) || String.IsNullOrEmpty(NumberPhoneTB.Text))
            {
                {
                    MessageBox.Show("Есть незаполненные поля", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                var database = Entities.Entities.GetContext();
                
                    var buyer = database.Buyers.FirstOrDefault(x => x.PhoneNumber == this.NumberPhoneTB.Text);

                    if(buyer != null && (buyer.Users.Email != LoginTB.Text || buyer.Users.Password != Hashing.GetHash(PasswordTB.Password)))
                    {
                        var result = MessageBox.Show("Пользователь под таким именем не найден!", "Ошибка авторизации", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    }

                    else if (buyer == null)
                    {
                        var result = MessageBox.Show("Пользователь не найден, хотите зарегистрироваться?", "Ошибка авторизации", MessageBoxButton.YesNo, MessageBoxImage.Information);
                        if (result == MessageBoxResult.Yes)
                        {
                            NavigationService.Navigate(new Registration());
                        }
                        LoginTB.Text = "";
                        PasswordTB.Text = "";
                        NumberPhoneTB.Text = "";

                    }
                    else if (buyer.Users.Email == LoginTB.Text && buyer.Users.Password == Hashing.GetHash(PasswordTB.Password) && buyer.PhoneNumber == NumberPhoneTB.Text)
                    {
                        MessageBox.Show($"Доброго времени суток, {buyer.Users.Name} {buyer.Users.Patronymic}! У Вас вышло авторизоваться!");
                        NavigationService.Navigate(new PageForBuyer());
                    }
                
            }
        }

       
    }
}
