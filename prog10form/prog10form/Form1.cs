using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prog10form
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ResultBox.Text = "Результат работы программы: " + Environment.NewLine;
			try
			{
				// Задание 1
				
				string path = @"C:\temp";
				Directory.CreateDirectory(path + @"\K1");
				DirectoryInfo k = new DirectoryInfo(path + @"\K1");
				ResultBox.Text += "Папка K1 создана" + Environment.NewLine;

				Directory.CreateDirectory(path + @"\K2");
				DirectoryInfo k2 = new DirectoryInfo(path + @"\K2");
				ResultBox.Text += "Папка K2 создана" + Environment.NewLine;

				// Задание 2
				File.Create(path + @"\K1\t1.txt").Close();
				ResultBox.Text += "Файл t1 был создан" + Environment.NewLine;
				string text1 = "Годовиков Вадим Артёмович, 2004 года рождения, место жительства г. Вязники" + Environment.NewLine;
				File.WriteAllText(path + @"\K1\t1.txt", text1, Encoding.UTF8);

				File.Create(path + @"\K1\t2.txt").Close();
				ResultBox.Text += "Файл t2 был создан" + Environment.NewLine;
				string text2 = "Годовиков Александр Артёмович, 2007 года рождения, место жительства г. Вязники";
				File.WriteAllText(path + @"\K1\t2.txt", text2, Encoding.UTF8);

				// Задание 3

				Directory.CreateDirectory(path + @"\K2");
				DirectoryInfo k3 = new DirectoryInfo(path + @"\K2");
				ResultBox.Text += "Папка K2 создана" + Environment.NewLine;

				File.Create(path + @"\K2\t3.txt").Close();
				ResultBox.Text += "Файл t3 был создан" + Environment.NewLine;

				File.WriteAllText(path + @"\K2\t3.txt", File.ReadAllText(path + @"\K1\t1.txt"), Encoding.UTF8);
				File.AppendAllText(path + @"\K2\t3.txt", File.ReadAllText(path + @"\K1\t2.txt"), Encoding.UTF8);

				ResultBox.Text += "Содержимое из файла t1 и t2 было записано в t3" + Environment.NewLine;

				// Задание 4

				FileInfo file1 = new FileInfo(path + @"\K1\t1.txt");
				FileInfo file2 = new FileInfo(path + @"\K1\t2.txt");
				FileInfo file3 = new FileInfo(path + @"\K2\t3.txt");

				ResultBox.Text += "Развёрнутая информация о файлах: " + Environment.NewLine;
				ResultBox.Text += $"Имя файла: {file1.Name}; Размер файла: {file1.Length}; Дата создания файла: {file1.CreationTime}" + Environment.NewLine;
				ResultBox.Text += $"Имя файла: {file2.Name}; Размер файла: {file2.Length}; Дата создания файла: {file2.CreationTime}" + Environment.NewLine;
				ResultBox.Text += $"Имя файла: {file3.Name}; Размер файла: {file3.Length}; Дата создания файла: {file3.CreationTime}" + Environment.NewLine;

				// Задание 5

				file2.MoveTo(path + @"\K2\t2.txt");
				ResultBox.Text += "Файл t2 был переещён в папку K2" + Environment.NewLine;

				// Задание 6

				file1.CopyTo(path + @"\K2\t1.txt");
				ResultBox.Text += "Файл t1 был скопирован в папку K1" + Environment.NewLine;

				Directory.Move(path + @"\K2", path + @"\ALL");
				ResultBox.Text += "Папка K2 была переименована в ALL" + Environment.NewLine;

				// Задание 7

				File.Delete(path + @"\K1\t1.txt");
				Directory.Delete(path + @"\K1");

				ResultBox.Text += "Папка K1 была удалена" + Environment.NewLine;

				// Задание 8

				DirectoryInfo dirAll = new DirectoryInfo(path + @"\ALL");
				FileInfo[] fileIn = dirAll.GetFiles();
				foreach (FileInfo files in fileIn)
				{
					ResultBox.Text += "" + Environment.NewLine;
					ResultBox.Text += $"Полное имя файла: {files.FullName.ToString()}" + Environment.NewLine;
					ResultBox.Text += $"Атрибуты: {files.Attributes.ToString()}" + Environment.NewLine;
					ResultBox.Text += $"Существует ли файл: {files.Exists.ToString()}" + Environment.NewLine;
					ResultBox.Text += $"Размер файла: {files.Length.ToString()}" + Environment.NewLine;
					ResultBox.Text += $"Расширение файла: {files.Extension.ToString()}" + Environment.NewLine;
				}
			}
			catch
			{
				MessageBox.Show("Для начала нужно удалить папочки)", "Ошибка");
				return;
			}
		}
	}
}
