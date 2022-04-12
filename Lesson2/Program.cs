using System;

namespace Lesson2_all
{

    internal class Program
    {

        /// <summary>
        /// Точка входа в программу
        /// </summary>
        static void Main()
        {
            float maxTemp = 0;                                          // Задаем нужные поля
            float minTemp = 0;
            float avgTemp = 0;
            int monthNumber = 0;


            Helpers.AskTemps(out minTemp, out maxTemp);                 //Запросить температуру и передать из нее переменные

            avgTemp = Helpers.AvgTemp(minTemp, maxTemp);                //Посчитать среднюю температуру

            Helpers.WriteAvgTemp(avgTemp);                              //Вывести сообщение о средней температуре

            Helpers.AskMonthNumber(out monthNumber);                    //Запросить номер месяца

            Helpers.WhichMonth(monthNumber, avgTemp);                   //Вывести информацию о месяце   


            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Вывести чек? y n: ");                        //Спросить нужно ли вывести чек
            if ((Console.ReadLine() == "y"))                            //Ввести символ "y" для продолжени, любой другой для пропуска
            {
                Helpers.WriteCheck();
            }

            Console.WriteLine();
            Console.Write("Вывести расписание работы? y n: ");          //Спросить нужно ли вывести расписание работы
            if ((Console.ReadLine() == "y"))                            //Ввести символ "y" для продолжени, любой другой для пропуска
            {
                Helpers.WriteRasp();
            }

            Helpers.PressAnyKey(0);                                     // Пауза перед закрытием консоли
            
        }   

    }
}
