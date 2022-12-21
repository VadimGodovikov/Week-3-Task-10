using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog10
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				// Задание 1

				string path = @"C:\temp";
				Directory.CreateDirectory(path + @"\K1");
				DirectoryInfo k = new DirectoryInfo(path + @"\K1");
				Console.WriteLine("Папка K1 создана");

				Directory.CreateDirectory(path + @"\K2");
				DirectoryInfo k2 = new DirectoryInfo(path + @"\K2");
				Console.WriteLine("Папка K2 создана");

				// Задание 2
				File.Create(path + @"\K1\t1.txt").Close();
				Console.WriteLine("Файл t1 был создан");
				string text1 = "Годовиков Вадим Артёмович, 2004 года рождения, место жительства г. Вязники" + Environment.NewLine;
				File.AppendAllText(path + @"\K1\t1.txt", text1, Encoding.UTF8);

				File.Create(path + @"\K1\t2.txt").Close();
				Console.WriteLine("Файл t2 был создан");
				string text2 = "Годовиков Александр Артёмович, 2007 года рождения, место жительства г. Вязники";
				File.AppendAllText(path + @"\K1\t2.txt", text2, Encoding.UTF8);

				// Задание 3

				Directory.CreateDirectory(path + @"\K2");
				DirectoryInfo k3 = new DirectoryInfo(path + @"\K2");
				Console.WriteLine("Папка K2 создана");

				File.Create(path + @"\K2\t3.txt").Close();
				Console.WriteLine("Файл t3 был создан");
				File.WriteAllText(path + @"\K2\t3.txt", File.ReadAllText(path + @"\K1\t1.txt"), Encoding.UTF8);
				File.AppendAllText(path + @"\K2\t3.txt", File.ReadAllText(path + @"\K1\t2.txt"), Encoding.UTF8);

				Console.WriteLine("Содержимое из файла t1 и t2 было записано в t3");

				// Задание 4

				FileInfo file1 = new FileInfo(path + @"\K1\t1.txt");
				FileInfo file2 = new FileInfo(path + @"\K1\t2.txt");
				FileInfo file3 = new FileInfo(path + @"\K2\t3.txt");

				Console.WriteLine("Развёрнутая информация о файлах: ");
				Console.WriteLine($"Имя файла: {file1.Name}; Размер файла: {file1.Length}; Дата создания файла: {file1.CreationTime}");
				Console.WriteLine($"Имя файла: {file2.Name}; Размер файла: {file2.Length}; Дата создания файла: {file2.CreationTime}");
				Console.WriteLine($"Имя файла: {file3.Name}; Размер файла: {file3.Length}; Дата создания файла: {file3.CreationTime}");

				// Задание 5

				file2.MoveTo(path + @"\K2\t2.txt");
				Console.WriteLine("Файл t2 был переещён в папку K2");

				// Задание 6

				file1.CopyTo(path + @"\K2\t1.txt");
				Console.WriteLine("Файл t1 был скопирован в папку K1");

				Directory.Move(path + @"\K2", path + @"\ALL");
				Console.WriteLine("Папка K2 была переименована в ALL");

				// Задание 7

				File.Delete(path + @"\K1\t1.txt");
				Directory.Delete(path + @"\K1");

				Console.WriteLine("Папка K1 была удалена");

				// Задание 8

				DirectoryInfo dirAll = new DirectoryInfo(path + @"\ALL");
				FileInfo[] fileIn = dirAll.GetFiles();
				foreach (FileInfo files in fileIn)
				{
					Console.WriteLine();
					Console.WriteLine($"Полное имя файла: {files.FullName.ToString()}");
					Console.WriteLine($"Атрибуты: {files.Attributes.ToString()}");
					Console.WriteLine($"Существует ли файл: {files.Exists.ToString()}");
					Console.WriteLine($"Размер файла: {files.Length.ToString()}");
					Console.WriteLine($"Расширение файла: {files.Extension.ToString()}");
				}
			}
			catch
			{
				Console.WriteLine("Для начала нужно удалить папочки)");
			}

		}
	}
}
