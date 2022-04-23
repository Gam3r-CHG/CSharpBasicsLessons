/*
Создать консольное приложение, которое при старте выводит приветствие, записанное в настройках
приложения (application-scope). Запросить у пользователя имя, возраст и род деятельности, а затем
сохранить данные в настройках. При следующем запуске отобразить эти сведения. Задать
приложению версию и описание.
*/

using System;
using System.Reflection;

namespace Lesson8_1
{
    internal class Program
    {
        static void Main()
        {
            ShowAppInfo();

            Console.WriteLine();

            ShowAppSettings();

            Console.WriteLine();
            
            ChangeAppSettings();

            PressAnyKey(0);

        }

        /// <summary>
        /// Поменять настройки приложения
        /// </summary>
        public static void ChangeAppSettings()
        {
            Console.Write("Введите Ваше имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите Ваш возраст: ");
            int.TryParse(Console.ReadLine(), out int age);
            Console.Write("Введите Вашу работу: ");
            string work = Console.ReadLine();

            Console.WriteLine("Вы ввели Имя:{0} Возраст:{1} Работу:{2}", name, age, work);

            Properties.Settings.Default.Name = name;
            Properties.Settings.Default.Age = age;
            Properties.Settings.Default.Work = work;
            Properties.Settings.Default.Save();

            WriteLineColor("Настройки приложения сохранены!", ConsoleColor.DarkGreen);
        }
        /// <summary>
        /// Вывести на консоль настройки приложения
        /// </summary>
        public static void ShowAppSettings()
        {
            Console.WriteLine("Приветствие записанное в настройках приложения: {0}", Properties.Settings.Default.Greeting);
            Console.WriteLine("Имя записанное в настройках приложения: {0}", Properties.Settings.Default.Name);
            Console.WriteLine("Возраст записанный в настройках приложения: {0}", Properties.Settings.Default.Age);
            Console.WriteLine("Работа записанная в настройках приложения: {0}", Properties.Settings.Default.Work);
        }


        /// <summary>
        /// Вывести в консоль информацию о текущем приложении
        /// </summary>
        public static void ShowAppInfo()
        {
            string applicationVersion = typeof(Program).Assembly.GetName().Version.ToString();
            string applicationName = typeof(Program).Assembly.GetName().Name;
            string applicationTitle = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;
            string applicationDescription =
                Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyDescriptionAttribute>().Description;

            Console.WriteLine($"Название приложения: \t{applicationName}");
            Console.WriteLine($"Заголовок приложения: \t{applicationTitle}");
            Console.WriteLine($"Описание приложения: \t{applicationDescription}");
            Console.WriteLine($"Версия приложения: \t{applicationVersion}");
        }


        /// <summary>
        /// Вывести цветной текст (без перевода строки)
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="color">(Необязательный параметр) Цвет текста. Например {ConsoleColor.Red}</param>
        public static void WriteColor(string text, ConsoleColor color = ConsoleColor.Gray)
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
        public static void WriteLineColor(string text, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;    //Установить цвет, если передан параметр
            Console.WriteLine(text);
            Console.ResetColor();               //Сбросить настройки цвета
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
