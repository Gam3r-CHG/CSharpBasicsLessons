/*
Задание 4(*)
Написать программу, вычисляющую число Фибоначчи для заданного значения
рекурсивным способом.
*/

using System;

namespace Lesson4_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass class1 = new MyClass();
            bool isContinue = true;
            Console.Write("Введите число: ");      //Запросить число      
            int nFibonacci = Convert.ToInt32(Console.ReadLine());

            //Если число больше 30, программа может долго считать, спросить разрешения продолжить
            if (nFibonacci > 30)  
            {
                isContinue = class1.AskForMore();
            }

            if (isContinue)
            {
                Console.WriteLine("Число Фибоначчи: " + class1.Fibonacci(nFibonacci));
            }

            class1.PressAnyKey(0);            
        }

        
    }
}
