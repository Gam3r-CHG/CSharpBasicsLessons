using System;
using System.IO;

namespace Lesson5_4
{
    internal class Helpers
    {
        static bool isWriteToFile;
        static bool isConsoleOut;
        static bool isFileWithDirectory;
        static string fileName = "dir.txt";
        static DirectoryInfo directoryName = new DirectoryInfo(@"H:\Downloads");
        static string consoleText = "";



        /// <summary>
        /// Запросить директорию
        /// </summary>
        static void AskForPath()
        {
            do
            {
                Console.Write("Введите путь: ");
                try { directoryName = new DirectoryInfo(Console.ReadLine()); }
                catch {}
                if (!directoryName.Exists) WriteLineColor("Ошибка! Директория не найдена.", ConsoleColor.Red);
            } while (!directoryName.Exists);
        }

        /// <summary>
        /// Показать начальное меню
        /// </summary>
        public static void ShowMenu()
        {
            Console.Clear();
            WriteLineColor("Для выбора нажмите клавишу от 1 до 8:", ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine($@"1. Ввести название папки (по умолчанию {directoryName})");
            Console.WriteLine("2. Вывести информацию о выбранной папке");
            Console.WriteLine("3. Вывести папки в указанной папке");
            Console.WriteLine("4. Вывести папки + все вложенные (рекурсивный метод)");
            Console.WriteLine();
            WriteLineColor("Переключатели опции:", ConsoleColor.Green);
            Console.WriteLine();
            if (isFileWithDirectory) { WriteLineColor("5. Переключить (выводить файлы или нет)", ConsoleColor.Red); } //Изменить цвет для включенных опций
            else { Console.WriteLine("5. Переключить (выводить файлы или нет)"); }
            if (isConsoleOut) { WriteLineColor("6. Переключить (выводить на консоль или нет)", ConsoleColor.Red); }
            else { Console.WriteLine("6. Переключить (выводить на консоль или нет)"); }
            if (isWriteToFile) { WriteLineColor("7. Переключить (выводить в файл <dir.txt> или нет)", ConsoleColor.Red); }
            else { Console.WriteLine("7. Переключить (выводить в файл <dir.txt> или нет)"); }
            Console.WriteLine();
            Console.WriteLine("8. Выйти из программы");
            Console.WriteLine();

            //Ждать пока нажмут кнопку
            MenuOptions(AskForKey(8));
        }


        /// <summary>
        /// Выбор программы меню
        /// </summary>
        /// <param name="option">Опция меню</param>
        static void MenuOptions(int option)
        {
            switch (option)
            {
                case 1:
                    //1. Ввести название папки (по умолчанию H:\Downloads)
                    Console.WriteLine();
                    Console.WriteLine();
                    AskForPath();
                    ShowMenu();
                    break;
                case 2:
                    //Вывести информацию о выбранной папке
                    DirectoryInfo();
                    PressAnyKey(1);
                    ShowMenu();
                    break;
                case 3:
                    //Вывести папки в указанной папке
                    Console.Clear();
                    consoleText = "";  //Сбросить значение строки
                    GetDirectory(directoryName);
                    WhatToDo();
                    PressAnyKey(1);
                    ShowMenu();
                    break;
                case 4:
                    //Вывести папки + все вложенные (рекурсивный метод)
                    Console.Clear();
                    consoleText = "";  //Сбросить значение строки
                    GetAllDirectories(directoryName, "", true, isFileWithDirectory);
                    WhatToDo();
                    PressAnyKey(1);
                    ShowMenu();
                    break;
                case 5:
                    //Переключить (выводить файлы или нет)
                    isFileWithDirectory = !isFileWithDirectory;
                    ShowMenu();
                    break;
                case 6:
                    //Переключить (выводить на консоль или нет)
                    isConsoleOut = !isConsoleOut;
                    ShowMenu();
                    break;
                case 7:
                    //Переключить (выводить в файл <dir.txt> или нет)
                    isWriteToFile = !isWriteToFile;
                    ShowMenu();
                    break;
                case 8:
                    //Выйти из программы
                    return;
            }
        }


        /// <summary>
        /// Запросить ввод с клавиатуры от 1 до "max"
        /// </summary>
        /// <param name="max">Максимальное число для запроса</param>
        /// <returns></returns>
        static int AskForKey(int max)
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            char pressKeyChar;
            int pressKeyNumber;

            //Запрашивать, пока пользователь не нажмет нужные клавиши (от 1 до "max")
            do
            {
                key = Console.ReadKey(true);
                pressKeyChar = key.KeyChar;
                int.TryParse(Convert.ToString(pressKeyChar), out pressKeyNumber);

            } while (pressKeyNumber <= 0 || pressKeyNumber > max);

            return pressKeyNumber;
        }


        /// <summary>
        /// Вывести цветной текст (без перевода строки)
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="color">(Необязательный параметр) Цвет текста. Например {ConsoleColor.Red}</param>
        static void WriteColor(string text, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;    //Установить цвет, если передан параметр
            Console.Write(text);
            Console.ResetColor();               //Сбросить настройки цвета
        }


        /// <summary>
        /// Вывести цветной текст (с переводом строки)
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="color">(Необязательный параметр) Цвет текста. Например {ConsoleColor.Red}</param>
        static void WriteLineColor(string text, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;    //Установить цвет, если передан параметр
            Console.WriteLine(text);
            Console.ResetColor();               //Сбросить настройки цвета
        }


        /// <summary>
        /// Вывести список папок, вложенных папок и файлов рекурсивным способом
        /// </summary>
        /// <param name="directory">Начальная директория</param>
        /// <param name="indent">Отступ (для оформления)</param>
        /// <param name="isLastDirectory">Последняя директория?</param>
        /// <param name="isPrintFile">Печатать файлы? (не обязательный параметр, по умолчанию false)</param>
        static void GetAllDirectories(DirectoryInfo directory, string indent, bool isLastDirectory, bool isPrintFile = false)
        {
            consoleText += indent;      //добавляем накопившийся отступ

            if (isLastDirectory)        //если последняя директория в списке
            {
                consoleText += "└─";    //добавляем символ
                indent += "  ";         //и увеличиваем отступ

            }
            else
            {
                consoleText += "├─";    //если не последняя в списке - добавляем символ
                indent += "│ ";         //и увеличиваем отступ
            }

            consoleText += directory.Name + "\n";   //добавляем название директории и перевод строки


            if (isPrintFile) GetFilesForDirectory(directory, indent);   //Если в аргументах метода isPrintFiles = true, запускам метод <печать файлов>

            DirectoryInfo[] subDirs = directory.GetDirectories();

            for (int i = 0; i < subDirs.Length; i++)
            {
                try //Чтобы избежать ошибок для системных папок
                {
                    GetAllDirectories(subDirs[i], indent, i == subDirs.Length - 1, isPrintFile);
                }
                catch { }
            }

        }

        /// <summary>
        /// Вывести список файлов в указанной директории
        /// </summary>
        /// <param name="directory">Директория</param>
        /// <param name="indent">Отступ (для оформления)</param>
        static void GetFilesForDirectory(DirectoryInfo directory, string indent)
        {
            for (int i = 0; i < directory.GetFiles().Length; i++)
            {
                consoleText += indent;
                if (i < directory.GetFiles().Length - 1)
                {
                    consoleText += "├─" + directory.GetFiles()[i] + "\n";  //Добавить отступ и название файла + перевод строки
                }
                else
                {
                    consoleText += "└─" + directory.GetFiles()[i] + "\n";  //Добавить отступ и название файла + перевод строки
                }
            }
        }


        /// <summary>
        /// Выбрать что делать с полученными данными (консоль/файл)
        /// </summary>
        static void WhatToDo()
        {
            if (isConsoleOut) Console.WriteLine(consoleText); //Если isConsoleOut = true, вывести все в консоль.
            if (isWriteToFile) WriteFile(); //Если isWriteToFile = true, вывести все в файл.
        }


        /// <summary>
        /// Вывести информацию о директории <directoryName>
        /// </summary>
        static void DirectoryInfo()
        {
            WriteLineColor("Информация о выбранной директории:", ConsoleColor.Green);
            Console.WriteLine("Родительская папка: {0}", directoryName.Parent);
            Console.WriteLine("Полное имя: {0}", directoryName.FullName);
            Console.WriteLine("Краткое имя: {0}", directoryName.Name);
            Console.WriteLine("Дата создания: {0}", directoryName.CreationTime);
        }


        /// <summary>
        /// Получить список директорий  и файлов (при включенной опции) 
        /// </summary>
        /// <param name="dir">Директория</param>
        static void GetDirectory(DirectoryInfo dir)
        {
            consoleText += $"\nПапки в директории {dir}:\n";

            foreach (var item in dir.GetDirectories())
            {
                consoleText += item + "\n";
            }

            if (isFileWithDirectory) { GetFiles(dir); }     //Если опция включена, запросить список файлов
        }


        /// <summary>
        /// Получить список файлов в директории 
        /// </summary>
        /// <param name="dir">Директория</param>
        static void GetFiles(DirectoryInfo dir)
        {
            consoleText += $"\nФайлы в директории {dir}:\n";

            foreach (var item in dir.GetFiles())
            {
                consoleText += item + "\n";
            }
        }


        /// <summary>
        /// Дописать информацию в файл <fileName>
        /// </summary>
        static void WriteFile()
        {

            File.AppendAllText(fileName, $"\nЗапись сделана: {GetTime()}\n");   //Добавить в запись время создания
            File.AppendAllText(fileName, consoleText);
            Console.WriteLine();
            Console.WriteLine("Данные успешно записаны.");
        }


        /// <summary>
        /// Получить текущее время в виде строки
        /// </summary>
        /// <returns></returns>
        static string GetTime()
        {
            return DateTime.Now.ToLongTimeString();
        }


        /// <summary>
        /// Поставить на паузу выполнение программы
        /// </summary>
        /// <param name="task">Варианты: 0 - выйти из программы; 1 - продолжить</param>
        public static void PressAnyKey(int task)
        {
            switch (task)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
                    Console.ReadKey(true);
                    break;

                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Для продолжения нажмите любую клавишу...");
                    Console.ReadKey(true);
                    break;

                default:
                    Console.ReadKey(true);
                    break;
            }


        }

    }
}
