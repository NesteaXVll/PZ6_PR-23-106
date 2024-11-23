using Module_PZ_3.Modules;
using Module_PZ_3.Services;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Module_PZ_3.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        int click;
        public Autho()
        {
            InitializeComponent();
        }

        private void btnEnterGuests_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Client(null, null));
        }
        private void GenerateCapctcha()
        {
            tbCaptcha.Visibility = Visibility.Visible;
            tblCaptcha.Visibility = Visibility.Visible;

            string capctchaText = CaptchaGeneratot.GenerateCaptchaText(6);
            tblCaptcha.Text = capctchaText;
            tblCaptcha.TextDecorations = TextDecorations.Strikethrough;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            click += 1;
            string login = tbLogin.Text.Trim();
            string password = tbPassword.Text.Trim();

            var db = Helper.GetContext();

            var user = db.Authorization.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
            if (click == 1)
            {
                if (user != null)
                {
                    MessageBox.Show("Вы вошли под: " + user.Roles.Name.ToString());
                    LoadPage(user.Roles.Name.ToString(), user);
                }
                else
                {
                    MessageBox.Show("Вы ввели логин или пароль неверно!");
                    GenerateCapctcha();
                    tbPassword.Clear();
                    /*
                     * Здесь должна быть оичстка поля с паролем
                     * Вывод капчи
                     */
                }
            }
            else if (click > 1)
            {
                if (user != null && tbCaptcha.Text == tblCaptcha.Text)
                {
                    MessageBox.Show("Вы вошли под: " + user.Roles.Name.ToString());
                    LoadPage(user.Roles.Name.ToString(), user);
                }
                else
                {
                    MessageBox.Show("Введите данные заново!");
                    GenerateCapctcha();
                    tbPassword.Clear();
                }
            }
        }
        private void LoadPage(string _role, Authorization authorization)
        {
            click = 0;
            switch (_role)
            {
                case "Администратор":
                    NavigationService.Navigate(new Client(authorization, _role));
                    break;
            }
        }
    }
}
