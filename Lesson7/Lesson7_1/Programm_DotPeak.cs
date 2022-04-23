/*
Задание 1
Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.
*/

using System;
using System.IO;

namespace Lesson5_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteFile(AskString());
            PressAnyKey(0);

        }

        /// <summary>
        /// Запрос данных для записи в файл
        /// </summary>
        /// <returns></returns>
        static string AskString()
        {
            string stringTest;

            do
            {
                Console.WriteLine("Введите данные которые нужно записать в файл и нажмите клавишу <Enter>:");
                stringTest = Console.ReadLine();

                if (stringTest.Length == 0)
                {
                    Console.WriteLine("Ошибка! Вы ничего не ввели.");
                }

            } while (stringTest.Length == 0);

            return stringTest;
        }

        /// <summary>
        /// Записать строку в файл
        /// </summary>
        /// <param name="stringToFile">Строка для записи</param>
        static void WriteFile(string stringToFile)
        {
            string fileName = "test.txt";
            File.WriteAllText(fileName, stringToFile);
            Console.WriteLine("Данные успешно записаны в файл");
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
