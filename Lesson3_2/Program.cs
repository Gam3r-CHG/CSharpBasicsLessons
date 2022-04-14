using System;

namespace Lesson3_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Создаем массив [5,2]
            string[,] phonesBook = new string[5, 2];

            phonesBook = new string[,]
            {
                { "Иванов Алексей", "8 - 495 - 123123" }, 
                { "Петров Сергей", "8 - 495 - 234234" }, 
                { "Сидоров Илья", "8 - 495 - 456456" }, 
                { "Рысаков Антон", "8 - 495 - 789789" }, 
                { "Гладышева Татьяна", "8 - 495 - 159753" }
            };                       

            Console.WriteLine();
            ShowStringArray(phonesBook); 

            Console.WriteLine();
            Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
            Console.ReadKey();

        }

        
        
        /// <summary>
        /// Вывод массива (телефонная книга)
        /// </summary>
        /// <param name="whatArray">Двухмерный массив</param>
        static void ShowStringArray(string[,] whatArray)
        {

            for (int i = 0; i < whatArray.GetLength(0); i++)
            {
                for (int j = 0; j < whatArray.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        Console.Write($" {i+1}. {whatArray[i, j]}");
                    }
                    else
                    {
                        Console.Write("\t\t" + whatArray[i, j]);
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
