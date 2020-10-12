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
                    ActionsWithFiles AWF = new ActionsWithFiles();

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
                        var filterDic = new Dictionary<int, Func<string, IEnumerable<StudentDTO>>>
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
                            OutputConsole(g);           
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

                        string studentName = Console.ReadLine();

                        Console.ForegroundColor = colorB;
                        // как лучше назвать переменную s?
                        var s = file.GetStudentInfo($"{studentName}.json");
                        OutputConsole(s);
                        Console.ForegroundColor = color_;

                        Console.WriteLine("Отредактировать?");
                        var editStudent = Console.ReadLine().ToLower();
                        if(editStudent == "да")
                        {
                            var llll = AWF.EditStudent(s);
                            OutputConsole(llll);
                        } 
                    }
                    void OutputConsole(StudentDTO s)
                    {
                        Console.WriteLine($"FIO: {s.FIO},\n Curriculum\nFaculty: {s.Curriculum.Faculty},\nSpeciality: {s.Curriculum.Speciality},\n" +
                        $"Course: {s.Curriculum.Course},\nGpoup: {s.Curriculum.Group},\n Address\nCity: {s.Address.City},\nPostIndex: {s.Address.PostIndex},\n" +
                        $"Street: {s.Address.Street},\n Contact\nPhone: {s.Contact.Phone},\nEmail: {s.Contact.Email}");
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
