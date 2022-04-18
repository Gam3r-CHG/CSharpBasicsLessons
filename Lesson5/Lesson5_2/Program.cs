/*
Написать программу, которая при старте дописывает текущее время в файл
«startup.txt».
*/

using System;
using System.IO;

namespace Lesson5_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Текущее время {GetTime()} будет записано в файл <startup.txt>");

            PressAnyKey(1);

            WriteFile($"Текущее время: {GetTime()}\n");

            PressAnyKey(0);
        }



        /// <summary>
        /// Дописать строку в файл
        /// </summary>
        /// <param name="stringToFile">Строка для записи</param>
        static void WriteFile(string stringToFile)
        {
            string fileName = "startup.txt";
            File.AppendAllText(fileName, stringToFile);
            Console.WriteLine("Данные успешно записаны в файл");
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
