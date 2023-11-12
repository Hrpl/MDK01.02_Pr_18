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
using System.Windows.Shapes;

namespace NewApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string userName;

		public MainWindow(string userName, bool OpenDoc, string textForLabel)
        {
            InitializeComponent();
            if (OpenDoc && textForLabel != "") // открывается ли это окно НЕ после чтения файла
            {
				LabelWithText.Text = textForLabel;
            }
			if (userName == "" || userName == "Гость")
			{
				userName = "Гость";
			}
			else
			{
				this.userName = userName;
			}
			UserName.Text = userName; // вывожу имя пользователя
		}

		//кнопка выхода из профиля
		private void ExitButton(object sender, RoutedEventArgs e) 
		{
			new LoginWindow().Show();
			this.Close();
            
		}

		//кнопка сохранения файла
		private void SaveButton(object sender, RoutedEventArgs e)
		{
            new SaveDocumentWindow(LabelWithText.Text).Show();
		}

		//кнопка открытия файла
		private void OpenButton(object sender, RoutedEventArgs e)
		{
            new OpenDocumentWindow(userName, LabelWithText.Text).Show();
            this.Close();
		}
	}
}
