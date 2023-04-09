using ComputerSalon.Entities;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ComputerSalon.Pages
{

    public partial class Registration : Page
    {
        private readonly Entities.Entities context;

        public Registration()
        {
            InitializeComponent();
            context = new Entities.Entities();
        }

        private void RegistrationForBuyerClick(object sender, RoutedEventArgs e)
        {
            string login = LoginTBRegistration.Text;
            string password = PasswordTBRegistration.Password;
            string phone = NumberPhoneTBRegistration.Text;
            string name = NameTBRegistration.Text;
            string surname = SurnameTBRegistration.Text;
            string patronymic = PatronymicTBRegistration.Text;


            if (new[] { login, password, phone, name, surname, patronymic }.Any(x => String.IsNullOrWhiteSpace(x)))
            {
                MessageBox.Show("Есть незаполненные поля", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (UserExists(login))
            {
                MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                LoginTBRegistration.Text = "";
                return;
            }

            // Если пользователь не существует, то регистрируем его в системе
            RegisterUser(new Users { Email = login, Password = password, Name = name, Surname = surname, Patronymic = patronymic }, phone);

            // Отображаем сообщение об успешной регистрации
            MessageBox.Show("Вы успешно зарегистрировались", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.Navigate(new PageForBuyer());

        }

        private bool UserExists(string login)
        {
            return context.Users.FirstOrDefault(x => x.Email == login) != null;
        }

        private void RegisterUser(Users user, string numberPhone)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                var buyer = new Buyers { PhoneNumber = numberPhone, UserId = user.UserId };
                context.Buyers.Add(buyer);
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show($"Error!");
            }
        }
    }
}
