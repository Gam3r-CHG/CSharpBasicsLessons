using System;

namespace Lesson4_4
{
    internal class MyClass
    {
        /// <summary>
        /// Поставить на паузу выполнение программы
        /// </summary>
        /// <param name="task">Варианты: 0 - выйти из программы; 1 - продолжить</param>
        public void PressAnyKey(int task)
        {
            switch (task)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
                    Console.ReadKey();
                    break;

                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Для продолжения нажмите любую клавишу...");
                    Console.ReadKey();
                    break;

                default:
                    Console.ReadKey();
                    break;
            }
        }

        /// <summary>
        /// Вернуть число Фибоначчи (рекурсивный метод)
        /// </summary>
        /// <param name="nFibonacci">Номер числа Фибоначчи</param>
        /// <returns></returns>
        public int Fibonacci(int nFibonacci)
        {
            if (nFibonacci == 0)
            {
                return 0;
            }
            if (nFibonacci == 1)
            {
                return 1;
            }
            return Fibonacci(nFibonacci - 1) + Fibonacci(nFibonacci - 2);
        }

        /// <summary>
        /// Спросить разрешение продолжить (в случае долгих расчетов)
        /// </summary>
        /// <returns></returns>
        public bool AskForMore()
        {
            Console.WriteLine("Вы ввели очень большое число!");
            Console.WriteLine("Вы уверены, что хотите продолжить? (y) (n) ");

            ConsoleKeyInfo consoleKey = Console.ReadKey(true);
            if (consoleKey.KeyChar == 'y')
            {
                Console.WriteLine("Хорошо, считаем;)");
                return true;
            }

            return false;
        }
    }
}
