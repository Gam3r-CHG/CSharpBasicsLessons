/*
Задание.
Написать консольное приложение Task Manager, которое выводит на экран запущенные процессы и
позволяет завершить указанный процесс. Предусмотреть возможность завершения процессов 
с помощью указания его ID или имени процесса. В качестве примера можно использовать консольные
утилиты Windows tasklist и taskkill.
*/



namespace Lesson6_1
{
    internal class Program
    {
        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            Helpers.ShowMenu();

            Helpers.PressAnyKey(0);
        }
    }
}
