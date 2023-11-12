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
	/// Логика взаимодействия для SaveDocumentWindow.xaml
	/// </summary>
	public partial class SaveDocumentWindow : Window
	{
		protected string textDocument;
		public SaveDocumentWindow(string textDocument)
		{
			InitializeComponent();

			this.textDocument = textDocument;
		}

		private void saveButton(object sender, RoutedEventArgs e)
		{
			// допустимая длина имени файла не менее 3 символов
			if (fileName.Text.Length > 2)
			{
				string path = $@"..\..\Files\{fileName.Text.ToString()}.txt";
				File.WriteAllText(path, textDocument);

				this.Close();
				System.Windows.Forms.MessageBox.Show(
						"Файл успешно сохранен!",
						"Сообщение",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information,
						MessageBoxDefaultButton.Button1);
				return;
				
			}
			else
			{
				System.Windows.Forms.MessageBox.Show(
						"Недопустимая длина имени файла.",
						"Сообщение",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error,
						MessageBoxDefaultButton.Button1);
			}
        }
    }
}
