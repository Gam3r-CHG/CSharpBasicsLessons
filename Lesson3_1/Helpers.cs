using System;

namespace Lesson3_1
{
    /// <summary>
    /// Вспомогательный класс с методами
    /// </summary>
    internal class Helpers
    {
        // Заданы 3 массива, как пример
        static int[,] array1 = { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 } };
        static int[,] array2 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        static int[,] array3 = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
        
        static Random rnd = new Random();

        /// <summary>
        /// Показать меню с выбором опций.
        /// </summary>
        public static void ShowMenu()
        {
            while (true) // Бесконечный цикл пока пользователь не сделает выбор
            {
                Console.Clear();
                Console.WriteLine("Для выбора действия нажмите на клавишу:");
                Console.WriteLine("1. Вывести массивы");
                Console.WriteLine("2. Вывести значения в массивах расположенных по диагонали");
                Console.WriteLine("3. Вывести все значения массива по диагонали");
                Console.WriteLine("4. Перезаписать массивы произвольными числами");
                Console.WriteLine("5. Закрыть программу");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.KeyChar) // Выбор в зависимости от нажатой клавиши
                {
                    case '1': //Вывести массивы

                        Console.Clear();

                        Console.WriteLine("Первый массив: ");
                        ShowIntArray(array1);
                        Console.WriteLine();
                        Console.WriteLine("Второй массив: ");
                        ShowIntArray(array2);
                        Console.WriteLine();
                        Console.WriteLine("Третий массив: ");
                        ShowIntArray(array3);
                        Console.WriteLine();

                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();

                        break;

                    case '2': //Вывести значения в массивах расположенных по диагонали

                        Console.Clear();

                        Console.Write("Первый массив по диагонали: ");
                        DiagIntArray(array1);
                        Console.WriteLine();
                        Console.Write("Второй массив по диагонали: ");
                        DiagIntArray(array2);
                        Console.WriteLine();
                        Console.Write("Третий массив по диагонали: ");
                        DiagIntArray(array3);
                        Console.WriteLine();

                        Console.WriteLine();
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();

                        break;

                    case '3': //Вывести все значения массива по диагонали

                        Console.Clear();

                        Console.WriteLine("Весь первый массив по диагонали: ");
                        DiagIntArrayAll(array1);
                        Console.WriteLine();
                        Console.WriteLine("Весь второй массив по диагонали: ");
                        DiagIntArrayAll(array2);
                        Console.WriteLine();
                        Console.WriteLine("Весь третий массив по диагонали: ");
                        DiagIntArrayAll(array3);
                        Console.WriteLine();

                        Console.WriteLine();
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();

                        break;

                    case '4': // Перезаписать массивы произвольными числами

                        Console.Clear();

                        WriteIntArray(array1, 10);
                        WriteIntArray(array2, 100);
                        WriteIntArray(array3, 1000);

                        Console.WriteLine();
                        Console.WriteLine("Массивы успешно перезаписаны.");

                        Console.WriteLine();
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();

                        break;

                    case '5': // Выход из программы

                        return;

                        break;
                }
            }
        }

        
        /// <summary>
        /// Вывод двухмерных массивов в консоль
        /// </summary>
        /// <param name="whatArray">Двухмерный массив</param>
        public static void ShowIntArray(int[,] whatArray)
        {
            for (int i = 0; i < whatArray.GetLength(0); i++)
            {
                for (int j = 0; j < whatArray.GetLength(1); j++)
                {
                    Console.Write(" " + whatArray[i, j]); ; ;
                }
                Console.WriteLine();
            }
        }


        /// <summary>
        /// Вывод значений двухмерных массивов расположенных по диагонали
        /// </summary>
        /// <param name="whatArray">Двухмерный массив</param> 
        public static void DiagIntArray(int[,] whatArray)
        {
            for (int i = 0, j = 0; whatArray.GetLength(0) > i && whatArray.GetLength(1) > j; i++, j++)
            {
                Console.Write($"{whatArray[i, j]} ");
            }
        }


        /// <summary>
        /// Вывод всех значений двухмерных массивов по диагонали в консоли
        /// </summary>
        /// <param name="whatArray">Двухмерный массив</param>
        public static void DiagIntArrayAll(int[,] whatArray)
        {
            string spaces = "";

            for (int i = 0; i < whatArray.GetLength(0); i++)
            {
                for (int j = 0; j < whatArray.GetLength(1); j++)
                {
                    Console.WriteLine(spaces + whatArray[i, j]);
                    spaces += " ";
                }
            }
        }


        /// <summary>
        /// Возвращает произвольное целое число в заданном диапазоне
        /// </summary>
        /// <param name="randomInt">Максимальное число</param>
        /// <returns></returns>
        public static int GetRandom(int randomInt)
        {
            //Второй вариант ;)
            //Random rnd = new Random();
            //Thread.Sleep(1); //Подождать 1 мс, чтобы числа были разными;)

            return rnd.Next(randomInt);
        }


        /// <summary>
        /// Заполнить таблицу произвольными числами
        /// </summary>
        /// <param name="whatArray">Двухмерный массив</param>
        /// <param name="rndD">Максимальное число</param>
        public static void WriteIntArray(int[,] whatArray, int rndD)
        {
            for (int i = 0; i < whatArray.GetLength(0); i++)
            {
                for (int j = 0; j < whatArray.GetLength(1); j++)
                {
                    whatArray[i, j] = GetRandom(rndD);
                }
            }

        }

    }
}
