using System;
using Student;
using System.Threading.Tasks;
using System.Reflection;


namespace StudentCard
{
    class Program
    {        
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {                    
                    ConsoleColor color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Список команд:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("1. Cписок студентов\t2. Информация о студенте\t3. Редактировать\t99. Выход из программы");
                    Console.ForegroundColor = color;
                    int op = Convert.ToInt32(Console.ReadLine());


                    GetFiles file = new GetFiles();
                    GetStudent student = new GetStudent();

                    //через if
                    if (op == 1)
                    {
                        Operation1();
                    }
                    else if (op == 2)
                    {
                        Operation2();
                    }
                    else
                    {
                        Console.WriteLine($"Неверная команда");
                        //throw new Exception("Неверная команда");
                    }
                    void Operation1()
                    {
                        var f = file.Files();
                        Console.ForegroundColor = ConsoleColor.Green;
                        foreach (var r in f)
                        {
                            Console.WriteLine(r);
                        }
                        Console.ForegroundColor = color;

                        Console.WriteLine("Отфильтровать по:\n1. Факультету\n2. Специальности\n3. Курсу\n4. Группе");
                        int command = Convert.ToInt32(Console.ReadLine());
                        Filter filter = new Filter();
                        filter.Filter1(command);
                    }
                    void Operation2()
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Выберите студента:");
                        var f = file.Files();
                        Console.ForegroundColor = ConsoleColor.Green;
                        foreach (var r in f)
                        {
                            Console.WriteLine(r);
                        }
                        Console.ForegroundColor = color;

                        string st = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        var s = student.GetStudentInfo($"{st}.json");
                        Console.WriteLine($"FIO: {s.FIO},\n Curriculum\nFaculty: {s.curriculum.Faculty},\nSpeciality: {s.curriculum.Speciality},\n" +
                        $"Course: {s.curriculum.Course},\nGpoup: {s.curriculum.Group},\n Address\nCity: {s.address.City},\nPostIndex: {s.address.PostIndex},\n" +
                        $"Street: {s.address.Street},\n Contact\nPhone: {s.contact.Phone},\nEmail: {s.contact.Email}");
                        Console.ForegroundColor = color;
                    }
                }
                catch (Exception e)
                {                    
                    Console.WriteLine($"Ошибка! {e.Message}");
                }

            }
        }
    }
}
