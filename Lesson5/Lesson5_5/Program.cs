/*
Задание 5 (*)

Список задач(ToDo-list):

  .написать приложение для ввода списка задач;
  .задачу описать классом ToDo с полями Title и IsDone;
  .на старте, если есть файл tasks.json/xml/bin (выбрать формат), загрузить
   из него массив имеющихся задач и вывести их на экран;
  .если задача выполнена, вывести перед её названием строку «[x]»;
  .вывести порядковый номер для каждой задачи;
  .при вводе пользователем порядкового номера задачи отметить задачу с этим
   порядковым номером как выполненную;
  .записать актуальный массив задач в файл tasks.json/xml/bin.

 */
using System;
using System.IO;
using Newtonsoft.Json;



namespace Lesson5_5
{
    public class ToDo
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }

    }
    internal class Program
    {
        static string[] jsonFile = new string[0];
        static bool isDelAll;


        /// <summary>
        /// Точка входа в программу
        /// </summary>
        static void Main()
        {
            ShowMenu();

            PressAnyKey(0);
        }

        /// <summary>
        /// Прочитать данные из массива (если уже существует) или из файла json
        /// </summary>
        static void ReadJson()
        {
            //Если массив еще не существует и пользователь сам не удалил все строки массива
            //и файл json существует, считать данные из него
            if (jsonFile.Length == 0 && !isDelAll && File.Exists("task1.json"))
            {
                jsonFile = File.ReadAllLines("task1.json");
            }

            //Если массив уже существует, вывести из него данные через десериализацию
            if (jsonFile.Length > 0)
            {
                for (int i = 0; i < jsonFile.Length; i++)
                {
                    ToDo task = JsonConvert.DeserializeObject<ToDo>(jsonFile[i]);

                    Console.WriteLine(PrintLines(task, i)); //вывести методом на консоль 
                }
            }
            else
            {   //Если нет, вывести ошибку
                WriteLineColor("Задач не найдено!", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Вывести данные из массива в нужном формате по индексу
        /// </summary>
        /// <param name="task">Передача класса ToDo</param>
        /// <param name="taskId">Номер индекса массива</param>
        /// <returns></returns>
        static string PrintLines(ToDo task, int taskId)
        {
            string isDone; //Объявить переменную

            //Присвоить значение если true - [Х] если false - [ ]
            if (task.IsDone) { isDone = "[X]"; } else { isDone = "[ ]"; }

            //Передать строку с отформатированными данными строки массива
            return $"{isDone}  {taskId + 1}. {task.Title}";
        }

        /// <summary>
        /// Показать начальное меню
        /// </summary>
        public static void ShowMenu()
        {
            Console.Clear();
            ReadJson();  //Вывести значения в массиве или (если еще нет массива) из файла
            Console.WriteLine();
            WriteLineColor("Для выбора нажмите клавишу от 1 до 4:", ConsoleColor.Green);
            
            //Менять цвет надписей для наглядности
            if (jsonFile.Length == 0)
            {
                WriteLineColor("1. Изменить статус задачи", ConsoleColor.DarkGray);
            }
            else
            {
                Console.WriteLine("1. Изменить статус задачи");
            }
            if (jsonFile.Length == 0)
            {
                WriteLineColor("2. Удалить задачу", ConsoleColor.DarkGray);
            }
            else
            {
                Console.WriteLine("2. Удалить задачу");
            }

            Console.WriteLine("3. Добавить задачу");
            Console.WriteLine("4. Выйти из программы и записать изменения");
            Console.WriteLine();

            //Ждать пока нажмут кнопку
            MenuOptions(AskForKey(4));
        }


        /// <summary>
        /// Выбор программы меню
        /// </summary>
        /// <param name="option">Опция меню</param>
        static void MenuOptions(int option)
        {
            switch (option)
            {
                case 1:
                    //Изменить статус задачи
                    AskChangeTaskStatus();
                    ShowMenu();
                    break;
                case 2:
                    //Удалить задачу
                    AskDelTask();
                    ShowMenu();
                    break;
                case 3:
                    //Добавить задачу
                    AddTask();
                    ShowMenu();
                    break;
                case 4:
                    //Выйти из программы
                    ExitAndSave();
                    break;
            }
        }


        /// <summary>
        /// Сохранить данные в файл json и выйти из программы
        /// </summary>
        static void ExitAndSave()
        {
            File.WriteAllText("task1.json", "");
            File.AppendAllLines("task1.json", jsonFile);
            Console.WriteLine("Файл json1.json успешно перезаписан.");
        }


        /// <summary>
        /// Запросить ввод с клавиатуры от 1 до "max"
        /// </summary>
        /// <param name="max">Максимальное число для запроса</param>
        /// <returns></returns>
        static int AskForKey(int max)
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            char pressKeyChar;
            int pressKeyNumber;

            //Запрашивать, пока пользователь не нажмет нужные клавиши (от 1 до "max")
            do
            {
                key = Console.ReadKey(true);
                pressKeyChar = key.KeyChar;
                int.TryParse(Convert.ToString(pressKeyChar), out pressKeyNumber);

            } while (pressKeyNumber <= 0 || pressKeyNumber > max);

            return pressKeyNumber;
        }


        /// <summary>
        /// Запрос номера задачи для изменения статуса
        /// </summary>
        static void AskChangeTaskStatus()
        {
            if (jsonFile.Length > 0) //Проверка, что массив не пустой
            {
                Console.Write("Введите номер задачи:");
                int.TryParse(Console.ReadLine(), out int taskId);
                ChangeTaskStatus(taskId); //Запустить метод изменения статуса
            }
            else
            {   //Если массив пустой, выдать ошибку
                WriteLineColor("Ошибка! Задач нет.", ConsoleColor.Red);
                PressAnyKey(1);
            }
        }

        /// <summary>
        /// Изменить статус задачи по ее номеру (по умолчанию 0)
        /// </summary>
        /// <param name="taskNumber"></param>
        static void ChangeTaskStatus(int taskNumber = 0)
        {
            //Проверка номера задачи (существует или нет)
            if (taskNumber > jsonFile.Length || taskNumber == 0)
            {
                WriteLineColor("Ошибка! Такой задачи не найдено.", ConsoleColor.Red);
                PressAnyKey(1);
                return;
            }

            ToDo task = JsonConvert.DeserializeObject<ToDo>(jsonFile[taskNumber - 1]);
            task.IsDone = !task.IsDone; //Инвертировать поле
            jsonFile[taskNumber - 1] = JsonConvert.SerializeObject(task);
        }

        /// <summary>
        /// Запрос номера задачи для удаления
        /// </summary>
        static void AskDelTask()
        {
            if (jsonFile.Length > 0) //Проверка, что массив не пустой
            {
                Console.Write("Введите номер задачи для удаления:");
                int.TryParse(Console.ReadLine(), out int taskId);
                DelArrayIndex(ref jsonFile, taskId - 1); //Удалить элемент массива
            }
            else
            {   //Если пустой - выдать ошибку
                WriteLineColor("Ошибка! Задач нет.", ConsoleColor.Red);
                PressAnyKey(1);
            }
        }


        /// <summary>
        /// Удалить элемент в массиве по ссылке
        /// </summary>
        /// <param name="arrayOld">Массив</param>
        /// <param name="index">Индекс элемента</param>
        /// <returns></returns>
        static void DelArrayIndex(ref string[] arrayOld, int index)
        {
            //Если массив пустой или указан несуществующий индекс
            if (arrayOld == null || index < 0 || index >= arrayOld.Length)
            {
                WriteLineColor("Ошибка! Такой задачи не найдено.", ConsoleColor.Red);
                PressAnyKey(1);
                return;

            }

            //Пересобрать массив, удалив строку по индексу
            string[] newArray = new string[arrayOld.Length - 1];

            for (int i = 0; i < index; i++)
            {
                newArray[i] = arrayOld[i];
            }

            for (int i = index + 1; i < arrayOld.Length; i++)
            {
                newArray[i - 1] = arrayOld[i];
            }
            arrayOld = newArray; //Присвоить по ref новый массив старому
            
            //Если массив после удаления строки пустой, присвоить isDelAll = true. Для последующих проверок.
            if (newArray.Length == 0) { isDelAll = true; } 

        }


        /// <summary>
        /// Добавить задачу в массив
        /// </summary>
        static void AddTask()
        {
            Console.Write("Введите название задачи:");
            string taskName = Console.ReadLine();
            if (taskName == "")  //Если ничего не ввели, выйти из метода
            {
                return;
            };


            if (jsonFile != null) //Если массив существует, изменить его размер
            {
                Array.Resize(ref jsonFile, jsonFile.Length + 1);
            }

            ToDo task = new ToDo(); //Задать начальные параметры задачи
            task.Title = taskName;
            task.IsDone = false;

            //Записать данные в массив через сериализацию
            if (jsonFile == null)  //Если массив пустой, записать в первый индекс
            {
                jsonFile = new string[1];
                jsonFile[0] = JsonConvert.SerializeObject(task);
            }
            //Если массив не пустой, записать в последний индекс
            else { jsonFile[jsonFile.Length - 1] = JsonConvert.SerializeObject(task); }
        }


        /// <summary>
        /// Вывести цветной текст (без перевода строки)
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="color">(Необязательный параметр) Цвет текста. Например {ConsoleColor.Red}</param>
        static void WriteColor(string text, ConsoleColor color = ConsoleColor.Gray)
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
        static void WriteLineColor(string text, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;    //Установить цвет, если передан параметр
            Console.WriteLine(text);
            Console.ResetColor();               //Сбросить настройки цвета
        }


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
    }
}
