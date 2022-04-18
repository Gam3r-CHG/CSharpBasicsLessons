/*
Задание 3
Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл.
*/


using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lesson5_3
{
    internal class Program
    {
        /// <summary>
        /// Тестовый класс
        /// </summary>
        [Serializable]
        public class Lesson
        {
            /// <summary>
            /// Числа
            /// </summary>
            public int Numbers1 { get; set; }
            public int Numbers2 { get; set; }
            public int Numbers3 { get; set; }
            public int Numbers4 { get; set; }
            public int Numbers5 { get; set; }
            
        }

        static Lesson testBin = new Lesson();


        /// <summary>
        /// Точка входа в программу
        /// </summary>
        static void Main()
        {
            IntitLesson();  //Задать начальные значения

            ShowMenu();     //Вывести меню
            
            PressAnyKey(0);
        }


        /// <summary>
        /// Вывести на экран значения из Lesson.Numbers
        /// </summary>
        static void ReadNumbers()
        {
            Console.WriteLine($"В Lesson.Numbers хранится 5 чисел: " +
                              $"{testBin.Numbers1}, {testBin.Numbers2}, " +
                              $"{testBin.Numbers3}, {testBin.Numbers4}, " +
                              $"{testBin.Numbers5}");
        }


        /// <summary>
        /// Задать начальные значения
        /// </summary>
        static void IntitLesson()
        {
            testBin.Numbers1 = 1;
            testBin.Numbers2 = 2;
            testBin.Numbers3 = 3;
            testBin.Numbers4 = 4;
            testBin.Numbers5 = 5;
        }

        /// <summary>
        /// Задать числа вручную
        /// </summary>
        static void AskForNumbers()
        {
            Console.WriteLine("Введите 5 чисел от 0 до 255, после каждого нажмите Enter:");

            try
            {
                testBin.Numbers1 = int.Parse(Console.ReadLine());
                testBin.Numbers2 = int.Parse(Console.ReadLine());
                testBin.Numbers3 = int.Parse(Console.ReadLine());
                testBin.Numbers4 = int.Parse(Console.ReadLine());
                testBin.Numbers5 = int.Parse(Console.ReadLine());
            }
            catch //Если введены не числа (int)
            {
                WriteLineColor("Числа введены с ошибкой!", ConsoleColor.Red);
                IntitLesson();
                PressAnyKey(1);
                return;
            }

            //Проверить на соблюдение условий 0..255
            if (testBin.Numbers1 >= 0
                && testBin.Numbers2 >= 0 && testBin.Numbers3 >= 0
                && testBin.Numbers4 >= 0 && testBin.Numbers5 >= 0
                && testBin.Numbers1 <= 255 && testBin.Numbers2 <= 255
                && testBin.Numbers3 <= 255 && testBin.Numbers4 <= 255
                && testBin.Numbers5 <= 255)
            {
                Console.WriteLine(
                    $"Вы ввели 5 чисел: {testBin.Numbers1}, {testBin.Numbers2}, {testBin.Numbers3}, {testBin.Numbers4}, {testBin.Numbers5}");
                PressAnyKey(1);
            }
            else
            {
                WriteLineColor("Числа введены с ошибкой!", ConsoleColor.Red);
                IntitLesson();
                PressAnyKey(1);
            }
        }


        /// <summary>
        /// Задать произвольные числа
        /// </summary>
        static void AskForNumbersRandom()
        {
            Random random = new Random();
            testBin.Numbers1 = random.Next(255);
            testBin.Numbers2 = random.Next(255);
            testBin.Numbers3 = random.Next(255);
            testBin.Numbers4 = random.Next(255);
            testBin.Numbers5 = random.Next(255);

            Console.WriteLine($"Задали произвольные числа: {testBin.Numbers1}, {testBin.Numbers2}, {testBin.Numbers3}, {testBin.Numbers4}, {testBin.Numbers5}");
            PressAnyKey(1);
        }


        /// <summary>
        /// Записать данные в файл
        /// </summary>
        static void WritedBin()
        {
            FileStream fs = new FileStream("testBin.bin", FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, testBin);
            fs.Close();

            Console.WriteLine($"Успешно записали числа в бинарный файл:{testBin.Numbers1}, {testBin.Numbers2}, {testBin.Numbers3}, {testBin.Numbers4}, {testBin.Numbers5}");
            PressAnyKey(1);
        }


        /// <summary>
        /// Считатать из файла
        /// </summary>
        static void ReadBin()
        {
            if (File.Exists("testBin.bin"))  //Проверить существует ли файл
            {
                FileStream fs = new FileStream("testBin.bin", FileMode.OpenOrCreate);
                BinaryFormatter formatter = new BinaryFormatter();
                testBin = (Lesson) formatter.Deserialize(fs);
                fs.Close();

                Console.WriteLine(
                    $"Успешно считали числа из бинарного файла:{testBin.Numbers1}, {testBin.Numbers2}, {testBin.Numbers3}, {testBin.Numbers4}, {testBin.Numbers5}");
                PressAnyKey(1);
            }
            else
            {
                WriteLineColor("Файл не существует!", ConsoleColor.Red);
                PressAnyKey(1);
            }

        }


        /// <summary>
        /// Показать начальное меню
        /// </summary>
        public static void ShowMenu()
        {
            Console.Clear();
            ReadNumbers();  //Вывести числа на экран
            Console.WriteLine();
            WriteLineColor("Для выбора нажмите клавишу от 1 до 5:", ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine("1. Ввести числа в Lesson.Numbers вручную");
            Console.WriteLine("2. Ввести числа в Lesson.Numbers Random");
            Console.WriteLine("3. Записать числа в бинарный файл");
            Console.WriteLine("4. Считать числа из бинарного файла");
            Console.WriteLine("5. Выйти из программы");
            Console.WriteLine();

            //Ждать пока нажмут кнопку
            MenuOptions(AskForKey(5));
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
                    //1. Ввести числа в Lesson.Numbers вручную
                    AskForNumbers();
                    ShowMenu();
                    break;
                case 2:
                    //Ввести числа в Lesson.Numbers Random
                    AskForNumbersRandom();
                    ShowMenu();
                    break;
                case 3:
                    //Записать числа в бинарный файл
                    WritedBin();
                    ShowMenu();
                    break;
                case 4:
                    //Считать числа из бинарного файла
                    ReadBin();
                    ShowMenu();
                    break;
                case 5:
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

    }
}
