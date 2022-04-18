/*
Задание 2
Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом, и
возвращающую число — сумму всех чисел в строке. Ввести данные с клавиатуры и вывести
результат на экран.
*/

using System;

namespace Lesson4_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string chisla = "";
            string text = "";
            int summaChisel = 0;
            int chislo = 0;

            for (int i = 0; i < args.Length; i++)                       //Проверить аргументы по очереди
            {                
                bool isChislo = int.TryParse(args[i], out chislo);

                text = text + " " + args[i];                            //Строка со всеми аргументами
                if (isChislo)
                {
                    summaChisel += chislo;                              //Сумма всех чисел (если они были)
                    chisla = chisla + " " + args[i];                    //Строка со всеми числами в аргументе (если они были)
                }                
            }

            Console.WriteLine($"Аргументы запуска приложения: {text}");
            if (summaChisel > 0)
            {
                Console.WriteLine($"В аргументах были числа: {chisla}");
                Console.WriteLine($"Сумма этих чисел: {summaChisel}");
            }
            else
            {
                Console.WriteLine("В аргументах чисел не было!");
            }


            Console.WriteLine();
            Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
