/*
Задание 1
Написать метод GetFullName(string firstName, string lastName, string patronymic),
принимающий на вход ФИО в разных аргументах и возвращающий объединенную 
строку с ФИО. Используя метод, написать программу, выводящую в консоль
3–4 разных ФИО.
*/


using System;

namespace Lesson4_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Тест использования метода:");
            Console.WriteLine();

            Console.WriteLine(GetFullName("Олег","Иванов","Петрович"));
            Console.WriteLine(GetFullName("Илья", "Сидоров", "Антонович"));
            Console.WriteLine(GetFullName("Максим", "Петров", "Сергеевич"));
            Console.WriteLine(GetFullName("Сергей", "Пушкин", "Олегович"));

            Console.WriteLine();
            Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
            Console.ReadKey();

        }


        /// <summary>
        /// Объединить в строку 3 аргумента
        /// </summary>
        /// <param name="firsName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="patronymic">Отчество</param>
        /// <returns></returns>
        static string GetFullName(string firsName, string lastName, string patronymic)
        {
            return lastName + " " + firsName + " " + patronymic;
        }
    }
}
