using System;
using Student;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace StudentCard
{
    class Program
    {        
        static void Main(string[] args)
        {
            ConsoleColor color_ = Console.ForegroundColor;
            ConsoleColor colorR = ConsoleColor.Red;
            ConsoleColor colorG = ConsoleColor.Green;
            ConsoleColor colorB = ConsoleColor.Blue;
            while (true)
            {
                try
                {                    
                    

                    Console.ForegroundColor = colorR;                    
                    Console.WriteLine("Список команд:");
                    Console.ForegroundColor = colorG;
                    Console.WriteLine("1. Cписок студентов\t2. Информация о студенте\t3. Создать\t4. Редактировать\t99. Выход из программы");
                    Console.ForegroundColor = color_;
                    int command = Convert.ToInt32(Console.ReadLine());


                    GetFiles file = new GetFiles();                    

                    //через if
                    if (command == 1)
                    {
                        StudentsList();
                    }
                    else if (command == 2)
                    {
                        StudentInfo();
                    }
                    else if (command == 3)
                    {
                        ActionsWithFiles AWF = new ActionsWithFiles();
                        AWF.AddStudent();
                    }
                    else
                    {
                        Console.WriteLine($"Неверная команда");
                        throw new Exception();
                    }
                    void StudentsList()
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
                        int filterBy_ = Convert.ToInt32(Console.ReadLine());

                        Console.ForegroundColor = colorB;
                        if (filterBy_ == 3)
                        {
                            Filter<int> filter = new Filter<int>();                            
                            var resultF = filter.FSCGFilter(filterBy_);
                            foreach (var r in resultF)
                                Console.WriteLine(r);                            
                        }
                        else
                        {
                            Filter<string> filter = new Filter<string>();                            
                            var resultF = filter.FSCGFilter(filterBy_);
                            foreach (var r in resultF)
                                Console.WriteLine(r);                            
                        }
                        
                        Console.ForegroundColor = colorR;
                        Console.WriteLine("Введите нужный параметр");
                        Console.ForegroundColor = color_;
                        var selectParam = Console.ReadLine();
                        Filter<string> filter1 = new Filter<string>();

                        //попытка сделать словарь
                        Dictionary<int, Func<string, IEnumerable<StudentDTO>>> filterDic = new Dictionary<int, Func<string, IEnumerable<StudentDTO>>>
                        {
                            { 1, filter1.FilterF },
                            { 2, filter1.FilterS },
                            { 3, filter1.FilterC },
                            { 4, filter1.FilterG }
                        };

                        var filtrationResult = filterDic[filterBy_](selectParam);

                        Console.ForegroundColor = colorB;
                        foreach ( var g in filtrationResult)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"FIO: {g.FIO},\n Curriculum\nFaculty: {g.curriculum.Faculty},\nSpeciality: {g.curriculum.Speciality},\n" +
                            $"Course: {g.curriculum.Course},\nGpoup: {g.curriculum.Group},\n Address\nCity: {g.address.City},\nPostIndex: {g.address.PostIndex},\n" +
                            $"Street: {g.address.Street},\n Contact\nPhone: {g.contact.Phone},\nEmail: {g.contact.Email}");                            
                        }
                        Console.ForegroundColor = color_;  
                    }
                    void StudentInfo()
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
                    Console.ForegroundColor = color_;
                }

            }
        }
    }
}
