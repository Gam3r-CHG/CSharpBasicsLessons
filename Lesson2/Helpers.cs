using System;
using System.Globalization;

namespace Lesson2_all
{
    internal class Helpers
    {
        /// <summary>
        /// Запрос минимальной и максимальной температуры
        /// </summary>
        /// <param name="minTemp">Минимальная температура</param>
        /// <param name="maxTemp">Максимальная температура</param>
        public static void AskTemps(out float minTemp, out float maxTemp)
        {
            bool tryMinTemp;
            bool tryMaxTemp;

            do
            {
                Console.Write("Введите минимальную температуру: \t");

                //Проверка на корректность введеных данных
                tryMinTemp = float.TryParse(Console.ReadLine(), out minTemp);
                if (!tryMinTemp) WriteLineColor("Ошибка! Невверные данные.", ConsoleColor.Red);

            } while (!tryMinTemp);

            do
            {
                Console.Write("Введите максимальную температуру: \t");

                //Проверка на корректность введеных данных
                tryMaxTemp = float.TryParse(Console.ReadLine(), out maxTemp);
                if (!tryMaxTemp) WriteLineColor("Ошибка! Невверные данные.", ConsoleColor.Red);

            } while (!tryMaxTemp);//Если данные введены некоректно, запросить еще раз

        }


        /// <summary>
        /// Метод расчета средней температуры
        /// </summary>
        /// <param name="minTemp">Минимальная температура</param>
        /// <param name="maxTemp">Максимальная температура</param>
        /// <returns>Возвращает среднюю температуру</returns>
        public static float AvgTemp(float minTemp, float maxTemp)
        {
            float avgTemp = (minTemp + maxTemp) / 2;
            return avgTemp;
        }


        /// <summary>
        /// Вывести результаты расчета средней температуры
        /// </summary>
        /// <param name="avgTemp">Средняя температура</param>
        public static void WriteAvgTemp(float avgTemp)
        {
            Console.WriteLine("Средняя температура: \t\t\t" + avgTemp);
            Console.WriteLine();
        }


        /// <summary>
        /// Запрос номера месяца и проверка корректности ввода
        /// </summary>
        /// <param name="monthNumber">Номер месяца</param>
        public static void AskMonthNumber(out int monthNumber)
        {
            bool tryMonthNumber;

            do
            {
                Console.Write("Введите номер текущего месяца: \t\t");

                //Проверка на корректность введеных данных
                tryMonthNumber = int.TryParse(Console.ReadLine(), out monthNumber);
                if (!tryMonthNumber || monthNumber <= 0 || monthNumber > 12)
                {
                    WriteLineColor("Ошибка! Невверные данные. Число месяца должно быть в диапазоне от 1 до 12", ConsoleColor.Red);
                }

            } while (!tryMonthNumber || monthNumber <= 0 || monthNumber > 12);//Если данные введены некорректно, запросить еще раз

        }


        /// <summary>
        /// Анализ и вывод данных о введеном месяце
        /// </summary>
        /// <param name="monthNumber">Номер месяца</param>
        /// <param name="avgTemp">Средняя температура</param>
        public static void WhichMonth(int monthNumber, float avgTemp)
        {
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthNumber);
            Console.WriteLine();
            Console.Write("Текущий месяц: ");
            WriteColor(monthName, ConsoleColor.Green);

            if ((monthNumber % 2) == 0)
            {
                Console.Write("\tЧисло месяца: четное");
            }
            else
            {
                Console.Write("\tЧисло месяца: не четное");
            }                     

            if ((monthNumber == 1 || monthNumber == 2 || monthNumber == 12) && avgTemp > 0)
            
            {
                WriteColor("\t\tДождливая зима;)", ConsoleColor.Blue);
            }
        }


        /// <summary>
        /// Метод вывода чека на консоль
        /// </summary>
        public static void WriteCheck()
        {
            //Тестовые данные для чека
            int checkKkm = 00075411;
            int checkNumber = 3969;
            long checkInn = 1087746942040;
            long checkEklz = 3851495566;
            string[] product1 = { "Молоко", "99,50" };
            string[] product2 = { "Хлеб", "47,99" };

            Console.WriteLine();
            Console.WriteLine("***********************");
            Console.WriteLine("ООО <Пример>");
            Console.WriteLine("Добро пожаловать");
            Console.WriteLine("ККМ " + checkKkm + "   # " + checkNumber);
            Console.WriteLine("ИНН " + checkInn);
            Console.WriteLine("ЭКЛЗ " + checkEklz);
            Console.WriteLine(DateTime.Now);
            Console.WriteLine();
            Console.WriteLine("наименование товара 1");
            Console.WriteLine(product1[0] + "  " + product1[1]);
            Console.WriteLine("наименование товара 2");
            Console.WriteLine(product2[0] + "  " + product2[1]);
            Console.WriteLine("ИТОГ");
            Console.WriteLine(decimal.Parse(product1[1]) + decimal.Parse(product2[1]));
            Console.WriteLine("НАЛИЧНЫМИ = " + (decimal.Parse(product1[1]) + decimal.Parse(product2[1])));
            Console.WriteLine("***********************");
        }


        /// <summary>
        /// Метод вывода расписания работы с использованием битовых масок
        /// </summary>
        public static void WriteRasp()
        {
            //Задаем рабочие дни компании 1
            Days workingDays1 = (Days)0b_0011110;
            //Задаем рабочие дни компании 2
            Days workingDays2 = (Days)0b_1111111;

            Console.WriteLine();

            WriteColor($"Рабочие дни компании номер 1: ", ConsoleColor.Green);
            Console.WriteLine(workingDays1);

            WriteColor($"Рабочие дни компании номер 2: ", ConsoleColor.Green);
            Console.WriteLine(workingDays2);

        }


        /// <summary>
        /// Поставить на паузу выполнение программы
        /// </summary>
        /// <param name="task">Варианты текса: 0 - выйти из программы; 1 - продолжить</param>
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
