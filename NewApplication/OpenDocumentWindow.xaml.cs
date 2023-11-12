using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NewApplication
{
	/// <summary>
	/// Логика взаимодействия для OpenDocumentWindow.xaml
	/// </summary>
	public partial class OpenDocumentWindow : Window
	{
		private string retString;
		private string userName;

		public OpenDocumentWindow(string userName, string text)
		{
			InitializeComponent();
			this.userName = userName;
			this.retString = text;
		}

		private void openButton(object sender, RoutedEventArgs e)
		{
			try // если такой файл есть
			{
				string path = $@"..\..\Files\{fileName.Text}.txt";
				
				retString = File.ReadAllText(path);

				System.Windows.Forms.MessageBox.Show(
					"Файл открыт!",
					"Сообщение",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information,
					MessageBoxDefaultButton.Button1);
				new MainWindow(userName, true, retString).Show();
				this.Close();
			}
			catch // если его нет
			{
				DialogResult result = System.Windows.Forms.MessageBox.Show(
					"Произошла ошибка, возможно, такой файл отсутствует.",
					"Ошибка",
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1);
				// можно выйти на главную страницу
				if(result == System.Windows.Forms.DialogResult.Cancel)
				{
					new MainWindow(userName, true, retString).Show();
					this.Close();
				}
			}
        }
    }
}
