using Authorization.Helpers;
using Authorization.Pages.User;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Authorization.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = Connecting.conn.User.FirstOrDefault(x => x.Login == TxbLogin.Text && x.Password == PsbPassword.Password);

                if (result != null)
                {
                    switch(result.Role.ShortName)
                    {
                        case "u":
                            Navigating.nav.Navigate(new UserMainPage());
                            break;
                        case "a":

                            break;

                    }
                    UserData.FullName = $"{result.Surname} {result.Name} {result.Patronomic}";
                    UserData.RoleName = result.Role.Name;

                    MessageBox.Show($"Здравствуйте {UserData.FullName}\nВы вошли как {UserData.RoleName}", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch
            {
                MessageBox.Show("Невереная свзязка Логина и Пароля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
