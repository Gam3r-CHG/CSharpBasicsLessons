using System;

namespace Lesson3_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string reverseLine;
            bool tryString = false;

            do
            {
                Console.Write("Введите текст и нажмите Enter: ");

                string readLine = Console.ReadLine();
                reverseLine = ReverseWord(readLine);
                if (reverseLine.Length == 0)
                {
                    tryString = false;
                    WriteLineColor("Ошибка! Текст не найден:)", ConsoleColor.Red);
                }
                else tryString = true;

            } while (!tryString);
            
            
            Console.Write("Ваш текст наоборот: ");
            Console.WriteLine(reverseLine);

            Console.WriteLine();
            Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
            Console.ReadKey();

        }


        
        /// <summary>
        /// Метод - перевернуть слово наоборот
        /// </summary>
        /// <param name="whichWord">Строка</param>
        /// <returns></returns>
        static string ReverseWord(string whichWord)
        {

            string reverse = "";
            for (int i = whichWord.Length - 1; i >= 0; i--)
            {                
                reverse = reverse + whichWord[i];
            }

            return reverse;
            

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
    }
}
