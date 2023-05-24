using ActiviPrilizhenie.Data;
using ActiviPrilizhenie.Windows;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ActiviPrilizhenie.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private string Code = "";
        private bool CodeActual = false;

        public LoginPage()
        {
            InitializeComponent();
            MainGrid.KeyDown += new KeyEventHandler(Enter_KeyDown);
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var login = LoginBox.Text.Trim();
                var user = ApplicationContext
                    .GetContext()
                    .Polzovateli.FirstOrDefault(en => en.Nomer == login);
                if (user != null)
                {
                    PasswordBox.IsEnabled = true;
                    PasswordBox.Opacity = 1.0;
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                    return;
                }
                if (!string.IsNullOrEmpty(PasswordBox.Password))
                {
                    if (user.Parol == PasswordBox.Password)
                    {
                        CodeBox.IsEnabled = true;
                        CodeBox.Opacity = 1.0;
                        EnterButton.Visibility = Visibility.Visible;
                        EnterButton.IsEnabled = true;

                        if (!string.IsNullOrEmpty(CodeBox.Text))
                        {
                            if (CodeBox.Text == Code)
                            {
                                if (!CodeActual)
                                {
                                    MessageBox.Show("Код неактуален");
                                    return;
                                }
                                var role = ApplicationContext
                                    .GetContext()
                                    .RoliPolzovateley.Find(user.IdRoli);
                                if (role.Nazvanie == "Abonent")
                                {
                                    UserData.Role = UserRole.Abonent;
                                }
                                if (role.Nazvanie == "Operator")
                                {
                                    UserData.Role = UserRole.Operator;
                                }
                                UserData.UserId = user.Id;
                                NavigationHelper.ChangeMainPage(new MenuPage());
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Неверный код");
                                return;
                            }
                        }
                        if (string.IsNullOrEmpty(Code))
                        {
                            Code = GenerateCode(6);
                            var modal = new LoginCodeModalWindow(Code);
                            modal.ShowDialog();
                            CodeTimer();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль");
                        return;
                    }
                }
            }
        }

        private void AbortButton_Click(object sender, RoutedEventArgs e)
        {
            LoginBox.Text = string.Empty;
            CodeBox.Text = string.Empty;
            PasswordBox.Password = string.Empty;
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginBox.Text.Trim();
            var user = ApplicationContext
                .GetContext()
                .Polzovateli.FirstOrDefault(en => en.Nomer == login);
            if (user == null)
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }

            if (!string.IsNullOrEmpty(PasswordBox.Password))
            {
                if (user.Parol == PasswordBox.Password)
                {
                    if (!string.IsNullOrEmpty(CodeBox.Text))
                    {
                        if (CodeBox.Text == Code)
                        {
                            if (!CodeActual)
                            {
                                MessageBox.Show("Код неактуален");
                                return;
                            }
                            var role = ApplicationContext
                                .GetContext()
                                .RoliPolzovateley.Find(user.IdRoli);
                            if (role.Nazvanie == "Abonent")
                            {
                                UserData.Role = UserRole.Abonent;
                            }
                            if (role.Nazvanie == "Operator")
                            {
                                UserData.Role = UserRole.Operator;
                            }
                            UserData.UserId = user.Id;
                            NavigationHelper.ChangeMainPage(new MenuPage());
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Неверный код");
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неверный пароль");
                    return;
                }
            }
        }

        private string GenerateCode(int length)
        {
            Random rnd = new Random();
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                result.Append(rnd.Next(0, 10).ToString());
            }

            return result.ToString();
        }

        private void ReloadCodeButton_Click(object sender, RoutedEventArgs e)
        {
            Code = GenerateCode(6);
            var modal = new LoginCodeModalWindow(Code);
            modal.ShowDialog();
            CodeTimer();
        }

        private async Task CodeTimer()
        {
            CodeActual = true;
            await Task.Delay(10000);
            CodeActual = false;
        }

        private void skip_Click(object sender, RoutedEventArgs e)
        {
            UserData.Role = UserRole.Abonent;
            UserData.UserId = new Guid("4D3AC389-C7A0-45A2-960B-CB5BEBF06D9D");
            NavigationHelper.ChangeMainPage(new MenuPage());
        }
    }
}
