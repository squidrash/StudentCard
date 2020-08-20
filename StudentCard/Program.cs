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
                    ConsoleColor color_ = Console.ForegroundColor;
                    ConsoleColor colorR = ConsoleColor.Red;
                    ConsoleColor colorG = ConsoleColor.Green;
                    ConsoleColor colorB = ConsoleColor.Blue;

                    Console.ForegroundColor = colorR;                    
                    Console.WriteLine("Список команд:");
                    Console.ForegroundColor = colorG;
                    Console.WriteLine("1. Cписок студентов\t2. Информация о студенте\t3. Редактировать\t99. Выход из программы");
                    Console.ForegroundColor = color_;
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
                        var f = file.GetAllFiles();
                        Console.ForegroundColor = colorB;
                        foreach (var r in f)
                        {
                            Console.WriteLine(r);
                        }

                        Console.ForegroundColor = colorR;
                        Console.WriteLine("Отфильтровать по:");

                        Console.ForegroundColor = colorG;
                        Console.WriteLine("1. Факультету\n2. Специальности\n3. Курсу\n4. Группе");

                        Console.ForegroundColor = color_;
                        int command = Convert.ToInt32(Console.ReadLine());

                        Console.ForegroundColor = colorB;
                        if (command == 3)
                        {
                            Filter<int> filter = new Filter<int>();                            
                            var resultF = filter.FSCGFilter(command);
                            foreach (var r in resultF)
                                Console.WriteLine(r);
                            
                        }
                        else
                        {
                            Filter<string> filter = new Filter<string>();                            
                            var resultF = filter.FSCGFilter(command);
                            foreach (var r in resultF)
                                Console.WriteLine(r);                            
                        }
                        Console.ForegroundColor = color_;
                        //var select = Console.ReadLine();
                        //Filter<string> filter1 = new Filter<string>();
                        //filter1.FilterResult<string>(select);

                        //Console.ForegroundColor = ConsoleColor.Blue;
                        //var resultF = filter.Filter1(command);
                        //foreach (var r in resultF)
                        //    Console.WriteLine(r);
                        //Console.ForegroundColor = color;

                    }
                    void Operation2()
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Выберите студента:");
                        var f = file.GetAllFiles();
                        Console.ForegroundColor = ConsoleColor.Green;
                        foreach (var r in f)
                        {
                            Console.WriteLine(r);
                        }
                        Console.ForegroundColor = color_;

                        string st = Console.ReadLine();

                        Console.ForegroundColor = colorB;
                        var s = file.GetStudentInfo($"{st}.json");
                        //var s = student.GetStudentInfo($"{st}.json");
                        Console.WriteLine($"FIO: {s.FIO},\n Curriculum\nFaculty: {s.curriculum.Faculty},\nSpeciality: {s.curriculum.Speciality},\n" +
                        $"Course: {s.curriculum.Course},\nGpoup: {s.curriculum.Group},\n Address\nCity: {s.address.City},\nPostIndex: {s.address.PostIndex},\n" +
                        $"Street: {s.address.Street},\n Contact\nPhone: {s.contact.Phone},\nEmail: {s.contact.Email}");
                        Console.ForegroundColor = color_;
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
