using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите Ваше имя: ");
            string person_name = Console.ReadLine();
            Console.WriteLine($"Привет, {person_name}, сегодня {DateTime.Now.ToShortDateString()}");
            Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
            Console.ReadKey();

        }
    }
}
