using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace Lesson6_1
{


    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    static class Helpers
    {
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


        /// <summary>
        /// Показать начальное меню
        /// </summary>
        public static void ShowMenu()
        {
            WriteLineColor("Для выбора нажмите клавишу от 1 до 9:", ConsoleColor.Green);
            Console.WriteLine("1. Вывести список процессов");
            Console.WriteLine("2. Поиск по названию");
            Console.WriteLine("3. Поиск по ID");
            Console.WriteLine("4. Убить процесс с номером ...");
            Console.WriteLine("5. Убить процесс с именем ...");
            Console.WriteLine("6. Записать список процессов в файл <processes.txt>");
            Console.WriteLine("7. Записать список процессов в JSon файл <processes.json>");
            Console.WriteLine("8. Записать список процессов в XML файл <processes.xml>");
            Console.WriteLine("9. Выйти из программы");
            Console.WriteLine();

            //Ждать пока нажмут кнопку
            MenuOptions(AskForKey(9));
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
                    //1. Вывести список процессов
                    Console.WriteLine();
                    ShowProcesses();
                    Console.WriteLine();
                    ShowMenu();
                    break;

                case 2:
                    //Поиск по названию
                    SearchProcesses(AskSearchProcesses());
                    Console.WriteLine();
                    ShowMenu();
                    break;
                case 3:
                    //Поиск по ID
                    SearchProcessesId(AskSearchProcessesId());
                    Console.WriteLine();
                    ShowMenu();
                    break;
                case 4:
                    //Убить процесс с номером ...
                    KillProcessId(AskKillProcessId());
                    Console.WriteLine();
                    ShowMenu();
                    break;
                case 5:
                    //Убить процесс с именем ...
                    KillProcessName(AskKillProcessName());
                    Console.WriteLine();
                    ShowMenu();
                    break;
                case 6:
                    //Записать список процессов в файл <processes.txt>"
                    WriteTasksToTXT();
                    Console.WriteLine();
                    ShowMenu();
                    break;
                case 7:
                    //Записать список процессов в JSon файл <processes.json>
                    WriteTasksToJson();
                    Console.WriteLine();
                    ShowMenu();
                    break;
                case 8:
                    //Записать список процессов в XML файл <processes.xml>"
                    WriteTasksToXML();
                    Console.WriteLine();
                    ShowMenu();
                    return;
                case 9:
                    //Выйти из программы
                    return;
            }
        }


        /// <summary>
        /// Вывести процессы
        /// </summary>
        static void ShowProcesses()
        {
            Process[] processes = Process.GetProcesses();

            int yCursor = Console.CursorTop;

            for (int i = 0; i < processes.Length; i++)
            {
                Console.Write($"ID: {processes[i].Id}");

                Console.SetCursorPosition(12, i + yCursor);
                Console.WriteLine($"Name: {processes[i].ProcessName}");
            }
        }


        /// <summary>
        /// Запросить название процесса для поиска
        /// </summary>
        /// <returns></returns>
        static string AskSearchProcesses()
        {
            string processName;
            Console.Write("Введите название процесса: ");
            processName = Console.ReadLine();

            return processName ?? "";
        }


        /// <summary>
        /// Найти процессы по имени
        /// </summary>
        /// <param name="processName">Имя процесса</param>
        static void SearchProcesses(string processName)
        {
            Process[] processes = Process.GetProcesses();

            int yCursor = Console.CursorTop;
            bool isFind = false;

            for (int i = 0; i < processes.Length; i++)
            {
                if (processes[i].ProcessName == processName)
                {
                    isFind = true;
                    Console.SetCursorPosition(0, yCursor);
                    Console.Write($"ID: {processes[i].Id}");
                    Console.SetCursorPosition(12, yCursor++);
                    Console.WriteLine($"Name: {processes[i].ProcessName}");
                }
            }

            if (!isFind) WriteLineColor($"Процессы с именем {processName} не найден!", ConsoleColor.Red);
        }


        /// <summary>
        /// Запросить Id процесса для поиска
        /// </summary>
        /// <returns></returns>
        static int AskSearchProcessesId()
        {
            int processId;
            Console.Write("Введите Id процесса: ");
            int.TryParse(Console.ReadLine(), out processId);

            return processId;
        }


        /// <summary>
        /// Найти процесс по Id
        /// </summary>
        /// <param name="processId">Id процесса</param>
        static void SearchProcessesId(int processId)
        {
            Process process = new Process();

            int yCursor = Console.CursorTop;

            try
            {
                process = Process.GetProcessById(processId);
                Console.SetCursorPosition(0, yCursor);
                Console.Write($"ID: {process.Id}");
                Console.SetCursorPosition(12, yCursor++);
                Console.WriteLine($"Name: {process.ProcessName}");
            }
            catch
            {
                WriteLineColor($"Процесс с Id {processId} не найден!", ConsoleColor.Red);
            }
        }


        /// <summary>
        /// Запросить название процесса, чтобы закрыть
        /// </summary>
        /// <returns></returns>
        static string AskKillProcessName()
        {
            string processName;
            Console.Write("Введите название процесса, который нужно закрыть: ");
            Console.ForegroundColor = ConsoleColor.Red;
            processName = Console.ReadLine();
            Console.ResetColor();

            return processName ?? "";
        }


        /// <summary>
        /// Закрыть процесс по названию
        /// </summary>
        /// <param name="id">Id процесса</param>
        static void KillProcessName(string processName)
        {
            Process[] processes = Process.GetProcesses();

            int yCursor = Console.CursorTop;
            bool isFind = false;

            for (int i = 0; i < processes.Length; i++)
            {
                if (processes[i].ProcessName == processName)
                {
                    isFind = true;

                    try
                    {
                        processes[i].Kill();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(0, yCursor);
                        Console.Write($"ID: {processes[i].Id}");
                        Console.SetCursorPosition(12, yCursor++);
                        Console.WriteLine($"Name: {processes[i].ProcessName}  - закрыт!");
                        Console.ResetColor();
                    }
                    catch
                    {
                        WriteLineColor($"Процесс с именем {processName} не удалось завершить!", ConsoleColor.Red); //Если не удалось закрыть, выдать ошибку
                    }
                }
            }

            if (!isFind) WriteLineColor($"Процесс с именем {processName} не найден!", ConsoleColor.Red);
        }


        /// <summary>
        /// Запросить Id процесса, чтобы закрыть
        /// </summary>
        /// <returns></returns>
        static int AskKillProcessId()
        {
            int processId;
            Console.Write("Введите ID процесса, чтобы закрыть: ");
            Console.ForegroundColor = ConsoleColor.Red;
            int.TryParse(Console.ReadLine(), out processId);
            Console.ResetColor();

            return processId;
        }


        /// <summary>
        /// Закрыть процесс по Id
        /// </summary>
        /// <param name="id">Id процесса</param>
        static void KillProcessId(int id)
        {
            Process process = new Process();

            try
            {
                process = Process.GetProcessById(id);
            }
            catch
            {
                WriteLineColor("Процесс не найден!", ConsoleColor.Red); //Если не найден, выдать ошибку
                return;
            }

            try
            {
                process.Kill();
                Console.WriteLine($"Процесс с Id {id} закрыт");
            }
            catch
            {
                WriteLineColor($"Процесс с номером {id} не удалось завершить!", ConsoleColor.Red); //Если не удалось закрыть, выдать ошибку
            }
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
        /// Запись списка процессов в файл processes.txt
        /// </summary>
        static void WriteTasksToTXT()
        {

            Process[] processes = Process.GetProcesses();
            
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < processes.Length; i++)
            {
                sb.Append($"ID: { processes[i].Id}".PadRight(15) + $"Name: { processes[i].ProcessName}\n");
            }

            File.WriteAllText("processes.txt", sb.ToString());

            Console.WriteLine("Данные успешно записаны в файл <processes.txt>.");

            PressAnyKey(1);

        }


        /// <summary>
        /// Запись списка процессов в файл processes.json
        /// </summary>
        static void WriteTasksToJson()
        {
            Process[] processes = Process.GetProcesses();
            
            StringBuilder stringBuilder = new StringBuilder();

            Task task = new Task();
            
            var options = new JsonSerializerOptions { WriteIndented = false };

            for (int i = 0; i < processes.Length; i++)
            {
                task.Id = processes[i].Id;
                task.Name = processes[i].ProcessName;
                
                stringBuilder.AppendLine(JsonSerializer.Serialize(task, options));
            }
            
            File.WriteAllText("processes.json", stringBuilder.ToString());

            Console.WriteLine("Данные успешно записаны в файл <processes.json>.");

            PressAnyKey(1);
        }


        /// <summary>
        /// Запись списка процессов в файл processes.xml
        /// </summary>
        static void WriteTasksToXML()
        {
            Process[] processes = Process.GetProcesses();
            
            StringWriter stringWriter = new StringWriter();

            Task task = new Task();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Task));

            for (int i = 0; i < processes.Length; i++)
            {
                task.Id = processes[i].Id;
                task.Name = processes[i].ProcessName;

                xmlSerializer.Serialize(stringWriter, task);
            }

            File.WriteAllText("processes.xml", stringWriter.ToString());
            stringWriter.Close();

            Console.WriteLine("Данные успешно записаны в файл <processes.xml>.");

            PressAnyKey(1);
        }
    }
}
