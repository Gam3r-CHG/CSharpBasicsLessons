/*
Задание 3
Написать метод по определению времени года. На вход подается число – порядковый номер
месяца. На выходе — значение из перечисления (enum) — Winter, Spring, Summer,
Autumn. Написать метод, принимающий на вход значение из этого перечисления и
возвращающий название времени года (зима, весна, лето, осень). Используя эти методы,
ввести с клавиатуры номер месяца и вывести название времени года. Если введено
некорректное число, вывести в консоль текст «Ошибка: введите число от 1 до 12».
*/

using System;


namespace Lesson4_3
{
    internal class Program
    {
        enum Seasons
        {
            Winter = 1,
            Spring = 2,
            Summer = 3,
            Autumn = 4
        }

        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args">Номер сезона года</param>
        static void Main(string[] args)
        {

            bool isArg = int.TryParse(args[0], out int argsInt);    //Получить номер сезона из аргументов
            if (!isArg || argsInt < 1 || argsInt > 4)
            {
                Console.WriteLine("Ошибка. В аргументах программы может быть только число от 1 до 4.");
                Console.WriteLine("Заменим Ваш аргумент на аргумент по умолчанию (1).");
                argsInt = 1;  //Если в аргументах после проверки не было нужного числа, установить {1}
            }

            Console.WriteLine($"Вы ввели в аргументах число {argsInt} - это " + WhichSeason(argsInt));


            while (true) //Бесконечный цикл, пока не будет введено корректное число

            {
                Console.Write("Введите номер месяца: "); //Запросить номер месяца

                bool isNumber = int.TryParse(Console.ReadLine(), out int numberMonth);

                if (numberMonth < 1 || numberMonth > 12)
                {
                    Console.WriteLine("Ошибка. Введите число от 1 до 12.");
                }
                else
                {
                    Console.WriteLine($"Вы ввели число {numberMonth}, это соответствует {WhichSeasonByMonth(numberMonth)}");
                    break;
                }

            }

            Console.WriteLine();
            Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
            Console.ReadKey();
        }

        /// <summary>
        /// Вывести название сезона из Enum
        /// </summary>
        /// <param name="numberSeason">Номер сезона от 1 до 4</param>
        /// <returns></returns>
        static string WhichSeason(int numberSeason)
        {
            var a = (Seasons)numberSeason;
            string b = Convert.ToString(a);
            return b;
        }

        /// <summary>
        /// Вывести название сезона из Enum по номеру месяца
        /// </summary>
        /// <param name="numberMonth">Номер месяца</param>
        /// <returns></returns>
        static string WhichSeasonByMonth(int numberMonth)
        {
            string whichSeason = "";

            switch (numberMonth)
            {
                case 1:
                case 2:
                case 12:
                    whichSeason = WhichSeason(1);
                    break;


                case 3:
                case 4:
                case 5:
                    whichSeason = WhichSeason(2);
                    break;

                case 6:
                case 7:
                case 8:
                    whichSeason = WhichSeason(3);
                    break;

                case 9:
                case 10:
                case 11:
                    whichSeason = WhichSeason(4);
                    break;

                default:
                    whichSeason = "";
                    break;
            }

            return whichSeason;

        }
    }
}
