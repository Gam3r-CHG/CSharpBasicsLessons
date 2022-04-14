using System;

namespace Lesson3_4
{
    internal class Helpers
    {

        public static Random rnd = new Random();
        static int[,] poleForGame = new int[10, 10];



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


        /// <summary>
        /// Запросить выбор опции
        /// </summary>
        public static void AskOptions()
        {
            while (true) // Бесконечный цикл пока пользователь не сделает выбор
            {

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.KeyChar) // Выбор в зависимости от нажатой клавиши
                {
                    case '1': //Показать поле

                        ShowMenu();

                        Console.WriteLine();
                        Console.WriteLine();

                        ShowPoleForGame(poleForGame);

                        break;

                    case '2': //Очистить поле

                        ShowMenu();

                        Console.WriteLine();
                        Console.WriteLine();

                        ClearPoleForGame(poleForGame);
                        ShowPoleForGame(poleForGame);

                        break;

                    case '3': //Расставить корабли

                        ShowMenu();

                        Console.WriteLine();
                        Console.WriteLine();

                        ClearPoleForGame(poleForGame);
                        PutShipsForGame(poleForGame);
                        ShowPoleForGame(poleForGame);

                        break;

                    case '4': // Расставить корабли 2 метод

                        ShowMenu();

                        Console.WriteLine();
                        Console.WriteLine();

                        ClearPoleForGame(poleForGame);
                        PutShipsForGame2(poleForGame);
                        ShowPoleForGame(poleForGame);

                        break;

                    case '5': // Расставить корабли вручную

                        ShowMenu();

                        Console.WriteLine();
                        Console.WriteLine();

                        ClearPoleForGame(poleForGame);
                        PutShipsForGameByHand(poleForGame);

                        //Для удобства, после последнего ввода, очистить консоль и вывести меню с полем.
                        ShowMenu();
                        Console.WriteLine();
                        Console.WriteLine();
                        ShowPoleForGame(poleForGame);

                        break;

                    case '6': // Выход из программы

                        return;

                        break;
                }
            }
        }


        /// <summary>
        /// Получить случайное число
        /// </summary>
        /// <param name="randomInt">Максимальное число</param>
        /// <returns></returns>
        public static int GetRandom(int randomInt)
        {
            return rnd.Next(randomInt);
        }


        /// <summary>
        /// Показать поле для игры
        /// </summary>
        /// <param name="whatArray">Двухмерный массив</param>
        public static void ShowPoleForGame(int[,] whatArray)
        {

            for (int i = 0; i < whatArray.GetLength(0); i++)
            {
                for (int j = 0; j < whatArray.GetLength(1); j++)
                {
                    if (whatArray[i, j] == 1)
                    {
                        ConsoleColor currentForeground = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X ");
                        Console.ForegroundColor = currentForeground;
                    }
                    else
                    {
                        Console.Write("O ");
                    }

                }
                Console.WriteLine();
            }

        }


        /// <summary>
        /// Очистить поле для игры
        /// </summary>
        /// <param name="whatArray">Двухмерный массив</param>
        public static void ClearPoleForGame(int[,] whatArray)
        {
            for (int i = 0; i < whatArray.GetLength(0); i++)
            {
                for (int j = 0; j < whatArray.GetLength(1); j++)
                {
                    whatArray[i, j] = 0;
                }
            }
        }


        /// <summary>
        /// Разместить корабли последовательно (метод 1). Не более 1 корабля на строке
        /// </summary>
        /// <param name="whatArray">Двухмерный массив</param>
        public static void PutShipsForGame(int[,] whatArray)
        {
            int numberOfShips = 0;

            while (numberOfShips < 10)
            {

                for (int i = 0; i < whatArray.GetLength(0) && numberOfShips < 10; i++)
                {
                    //Разместить не более 1 корабля на строке
                    for (int j = 0, thisLineNumber = 0; j < whatArray.GetLength(1) && numberOfShips < 10 && thisLineNumber < 1; j++)
                    {
                        int isShip = GetRandom(2);
                        if (isShip != 0)
                        {
                            thisLineNumber++;
                            numberOfShips++;
                        }
                        whatArray[i, j] = isShip;
                    }
                }

            }
        }


        /// <summary>
        /// Разместить корабли перебором (метод 2)
        /// </summary>
        /// <param name="whatArray">Двухмерный массив</param>
        public static void PutShipsForGame2(int[,] whatArray)
        {
            int numberOfShips = 0;

            while (numberOfShips < 10)                              //Пока не установим 10 1 палубных кораблей
            {
                int i = GetRandom(10);                              //Сначала подбираем координаты
                int j = GetRandom(10);

                if (whatArray[i, j] == 0)                           //Проверяем свободно ли место
                {
                    whatArray[i, j] = 1;                            //Ставим корабль
                    numberOfShips++;                                //Увеличиваем переменную {количество кораблей}
                }
            }
        }


        /// <summary>
        /// Разместить корабли вручную
        /// </summary>
        /// <param name="whatArray"></param>
        public static void PutShipsForGameByHand(int[,] whatArray)
        {
            int numberOfShips = 0;
            
            Console.Write("Сколько хотите разместить кораблей? Введите число не больше 10: ");      //Запросить сколько кораблей нужно разместить
            bool tryNumberOfShips = int.TryParse(Console.ReadLine(), out numberOfShips);


            if (!tryNumberOfShips || numberOfShips > 10 || numberOfShips <= 0)                      //Проверить на корректность введенных чисел
            {
                ConsoleColor currentForeground = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы ввели неверные или слишком большие цифры, установим количество по умолчанию (5).");
                Console.ForegroundColor = currentForeground;
                numberOfShips = 5;                                                                  //Если ввели количество кораблей с ошибкой - установить значение {5}
            }

            Console.WriteLine("Введите координаты кораблей от числами от 1 до 10:");                //Запросить координаты кораблей которые нужно разместить

            for (int i = 0; i < numberOfShips; i++)
            {
                int shipX;
                int shipY;
                Console.Write($"Введите координаты (x) для {i + 1} корабля:");
                bool tryX = int.TryParse(Console.ReadLine(), out shipX);
                Console.WriteLine();
                Console.Write($"Введите координаты (y) для {i + 1} корабля:");
                bool tryY = int.TryParse(Console.ReadLine(), out shipY);
                Console.WriteLine();

                if (tryX && tryY && shipX > 0 && shipX <= 10 && shipY > 0 && shipY <= 10)           //Проверить на корректность введенных чисел
                {
                    if (whatArray[shipX - 1, shipY - 1] == 0)                                       //Проверка свободно ли место
                    {
                        whatArray[shipX - 1, shipY - 1] = 1;
                    }
                    else
                    {
                        ConsoleColor currentForeground = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка. Эти координаты уже заняты, введите еще раз");    //Если занято, вывести сообщение об ошибке
                        Console.ForegroundColor = currentForeground;
                        i--;
                    }
                }
                else
                {
                    ConsoleColor currentForeground = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка. Неверные данные.");                                 //Если данные некорректные, вывести сообщение об ошибке
                    Console.ForegroundColor = currentForeground;
                    i--;
                }
            }
        }


        /// <summary>
        /// Показать меню
        /// </summary>
        public static void ShowMenu()
        {
            //Очистить консоль и вывести меню
            Console.Clear();
            ConsoleColor currentForeground = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Для выбора действия нажмите на клавишу:");
            Console.WriteLine("1. Вывести поле");
            Console.WriteLine("2. Очистить поле");
            Console.WriteLine("3. Расположит корабли последовательно");
            Console.WriteLine("4. Расположит корабли перебором");
            Console.WriteLine("5. Расположит корабли вручную");
            Console.WriteLine("6. Закрыть программу");
            Console.ForegroundColor = currentForeground;
        }



    }
}
