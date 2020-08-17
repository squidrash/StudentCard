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
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Список команд:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Cписок студентов\t2. Информация о студенте\t99. Выход из программы");
                Console.ForegroundColor = color;
                int op = Convert.ToInt32(Console.ReadLine());
                
                GetFiles file = new GetFiles();
                GetStudent student = new GetStudent();

                // Через switch
                //switch (op)
                //{
                //    case 1:
                //        Console.ForegroundColor = ConsoleColor.Red;
                //        var f = file.Files();
                //        Console.ForegroundColor = ConsoleColor.Green;
                //        foreach (var r in f)
                //        {                            
                //            Console.WriteLine(r);
                //        }
                //        Console.ForegroundColor = color;
                //        break;
                //    case 2:// как сделать так чтобы не повторять функционал case 1?
                //        Console.ForegroundColor = ConsoleColor.Red;
                //        Console.WriteLine("Выберите студента:");
                //        f = file.Files();
                //        Console.ForegroundColor = ConsoleColor.Green;
                //        foreach (var r in f)
                //        {                            
                //            Console.WriteLine(r);
                //        }

                //        Console.ForegroundColor = color;
                //        string st = Console.ReadLine();

                //        Console.ForegroundColor = ConsoleColor.Green;
                //        var s = student.GetStudentInfo($"{st}.json");
                //        Console.WriteLine($"FIO: {s.FIO},\n Curriculum\nFaculty: {s.curriculum.Faculty},\nSpeciality: {s.curriculum.Speciality},\n" +
                //        $"Course: {s.curriculum.Course},\nGpoup: {s.curriculum.Group},\n Address\nCity: {s.address.City},\nPostIndex: {s.address.PostIndex},\n" +
                //        $"Street: {s.address.Street},\n Contact\nPhone: {s.contact.Phone},\nEmail: {s.contact.Email}");
                //        Console.ForegroundColor = color;
                //        break;

                //    case 99:
                //        break;
                //    default:
                //        throw new Exception("Неверная команда!");
                //}

                //через if
                if(op == 1)
                {
                    Operation1();
                }
                if(op == 2)
                {
                    Operation2();
                }
                void Operation1()
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    var f = file.Files();
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (var r in f)
                    {
                        Console.WriteLine(r);
                    }
                    Console.ForegroundColor = color;
                }
                void Operation2()
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Выберите студента:");
                    Operation1();
                    string st = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Green;
                    var s = student.GetStudentInfo($"{st}.json");
                    Console.WriteLine($"FIO: {s.FIO},\n Curriculum\nFaculty: {s.curriculum.Faculty},\nSpeciality: {s.curriculum.Speciality},\n" +
                    $"Course: {s.curriculum.Course},\nGpoup: {s.curriculum.Group},\n Address\nCity: {s.address.City},\nPostIndex: {s.address.PostIndex},\n" +
                    $"Street: {s.address.Street},\n Contact\nPhone: {s.contact.Phone},\nEmail: {s.contact.Email}");
                    Console.ForegroundColor = color;


                }

            }
        }
    }
}
