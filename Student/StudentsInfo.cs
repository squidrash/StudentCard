using System;

namespace Student
{
    public class StudentsInfo
    {
        public StudentDTO StudentsIf()
        {
            GetFiles student = new GetFiles();
            GetStudent student1 = new GetStudent();
            Console.WriteLine("Выберите студента:");
            student.Files();
            string st = Console.ReadLine();
            var s = student1.GetStudentInfo($"{st}.json");
            return s;
            //switch (st)
            //{
            //    case "ivan":                    
            //        student1.GetStudentInfo("/ivan.json");
            //        break;
            //    case "nik":                    
            //        student1.GetStudentInfo("/nik.json");
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}
