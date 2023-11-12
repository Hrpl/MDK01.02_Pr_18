using NewApplication.Models;
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
using NewApplication.Models;
using System.Windows.Forms;

namespace NewApplication
{
    // первым открывается это окно
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton(object sender, RoutedEventArgs e)
        {
            string loginUser = LoginTextBox.Text;
            string passwordUser = PasswordTextBox.Password;

            using(NewApplicationContext db = new NewApplicationContext())
            {
                Users user = new Users();

                // если и логин и пароль пусты, то пользователь входит как гость
                if (loginUser == "" && passwordUser == "")
                {
					System.Windows.Forms.MessageBox.Show(
						"Вы зашли как гость.",
					    "Сообщение",
					    MessageBoxButtons.OK,
					    MessageBoxIcon.Information,
					    MessageBoxDefaultButton.Button1);

                    new MainWindow(loginUser, false, "").Show();
                    this.Close();
                }
                else
                {
                    //  проверка на зарегистрированного ползователя
					Users us = db.Users.Where(u => u.Login == loginUser && u.Password == passwordUser).FirstOrDefault() as Users;
					if (us != null)
                    {
                        new MainWindow(loginUser, false, "").Show();
                        this.Close();
                    }
                    else
                    {
						System.Windows.Forms.MessageBox.Show(
						    "Неверный логин или пароль",
							"Ошибка",
						    MessageBoxButtons.OK,
						    MessageBoxIcon.Error,
						    MessageBoxDefaultButton.Button1);
					}
                }
            }
        }

		private void RegistrationButton(object sender, RoutedEventArgs e)
		{
			new RegistrationWindow().Show();
			this.Close();
		}
	}
}
