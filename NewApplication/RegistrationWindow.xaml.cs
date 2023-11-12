using NewApplication.Models;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace NewApplication
{
	/// <summary>
	/// Логика взаимодействия для Window1.xaml
	/// </summary>
	public partial class RegistrationWindow : Window
	{
		public RegistrationWindow()
		{
			InitializeComponent();
		}

		private void RegButton(object sender, RoutedEventArgs e)
		{
			using (NewApplicationContext db = new NewApplicationContext())
			{
				string loginUser = LoginTextBox.Text;
				string passwordUser = PasswordTextBox.Password;

				bool trueUser = true;
				int trueLenghtLogin = 0, trueLenghtPassword = 0; // количество правильных значений

				// допустимые символы
				char[] lowerDictionaryEn = "abcdeifjhijklmnopqrstuwxyz".ToCharArray();
				char[] upperDictionaryEn = "ABCDEIFJHIJKLMNOPQRSTUWXYZ".ToCharArray();

				char[] lowerDictionaryRu = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToCharArray();
				char[] upperDictionaryRu = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToCharArray();

				char[] numeric = "1234567890".ToCharArray();

				char[] punctuation = "._-<>?".ToCharArray();

				if (LoginTextBox.Text.Length > 21 || LoginTextBox.Text.Length < 3) // длина логина больше 21 или меньше 3 символов
				{
					trueUser = false;
				}
				else if (PasswordTextBox.Password.Length < 8) // длина пароля меньше 8 символов
				{
					trueUser = false;
				}
				else
				{
					#region Валидация логина
					for (int i = 0; i < loginUser.Length; i++)
					{
						if (lowerDictionaryEn.Contains(loginUser[i]))
						{
							trueLenghtLogin += 1;
						}
						if (upperDictionaryEn.Contains(loginUser[i]))
						{
							trueLenghtLogin += 1;
						}
						if (lowerDictionaryRu.Contains(loginUser[i]))
						{
							trueLenghtLogin += 1;
						}
						if (upperDictionaryRu.Contains(loginUser[i]))
						{
							trueLenghtLogin += 1;
						}
						if (numeric.Contains(loginUser[i]))
						{
							trueLenghtLogin += 1;
						}
						if (punctuation.Contains(loginUser[i]))
						{
							trueLenghtLogin += 1;
						}
					}
					#endregion

					#region Валидация пароля
					for (int i = 0; i < passwordUser.Length; i++)
					{
						if (lowerDictionaryEn.Contains(passwordUser[i]))
						{
							trueLenghtPassword += 1;
						}
						if (upperDictionaryEn.Contains(passwordUser[i]))
						{
							trueLenghtPassword += 1;
						}
						if (lowerDictionaryRu.Contains(passwordUser[i]))
						{
							trueLenghtPassword += 1;
						}
						if (upperDictionaryRu.Contains(passwordUser[i]))
						{
							trueLenghtPassword += 1;
						}
						if (numeric.Contains(passwordUser[i]))
						{
							trueLenghtPassword += 1;
						}
						if (punctuation.Contains(passwordUser[i]))
						{
							trueLenghtPassword += 1;
						}
					}
					#endregion

					// если длина логина или пароля не совпала с количеством правильных символов в логине или пароле 
					if(loginUser.Length != trueLenghtLogin || passwordUser.Length != trueLenghtPassword)
					{ 
						trueUser = false;
					}
				}

				if(trueUser) // все правильно
				{
					
					Users newUser = new Users()
					{
						Login = loginUser,
						Password = passwordUser
					};

					db.Users.Add(newUser);
					db.SaveChanges();

					System.Windows.Forms.MessageBox.Show(
					"Регистрация прошла успешно!",
					"Сообщение",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information,
					MessageBoxDefaultButton.Button1);

					new LoginWindow().Show();
					this.Close();
				}
				else // ошибка в данных
				{
					System.Windows.Forms.MessageBox.Show(
					"Недопустимые значения для логина и пароля:\n" +
					"Возможные значения:\n" +
					"Длина логина от 3 до 21 символов, длина пароля не менее 8 символов\n" +
					$"Символы: A-Z, a-z, А-Я, а-я, 0-9 ._-<>?",
					"Ошибка",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1);
					return;
				}
			}
		}
	}
}
