using System;
using Student;
using System.Threading.Tasks;


namespace StudentCard
{
    class Program
    {        
        static void Main(string[] args)
        {
            while (true)
            {
                //GetFiles student = new GetFiles();
                SelectOP selectOP = new SelectOP();
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Список команд:");
                Console.WriteLine("1. Cписок студентов\t2. Информация о студенте\t99. Выход из программы");
                Console.ForegroundColor = color;
                int op = Convert.ToInt32(Console.ReadLine());

                
                selectOP.Operation(op);
                //student.Files();
            }
        }
    }
}
