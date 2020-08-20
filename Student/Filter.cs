using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Student
{
    public class Filter
    {

        List<StudentDTO> studentF = new List<StudentDTO>();
        public void Filter1(int op)
        {
            string dirName = "StudentCards";
            if (Directory.Exists(dirName))
            {
                var files = Directory.GetFiles(dirName)
                    .Where(x => x.EndsWith(".json"))
                    .Select(x => x.Replace("StudentCards/", ""));
                foreach (var file in files)
                {
                    //Console.WriteLine(f);
                    var path = Path.Combine("StudentCards", $"{file}");

                    var jsonString = File.ReadAllText(path);                    
                    var student = JsonSerializer.Deserialize<StudentDTO>(jsonString);                    
                    studentF.Add(student);
                }
                //var select = from student in studentF
                //             where student.curriculum.Course < 3
                //             select student;


                //foreach (var s in select)
                //    Console.WriteLine($"FIO: {s.FIO},\n Curriculum\nFaculty: {s.curriculum.Faculty},\nSpeciality: {s.curriculum.Speciality},\n" +
                //        $"Course: {s.curriculum.Course},\nGpoup: {s.curriculum.Group},\n Address\nCity: {s.address.City},\nPostIndex: {s.address.PostIndex},\n" +
                //        $"Street: {s.address.Street},\n Contact\nPhone: {s.contact.Phone},\nEmail: {s.contact.Email}");

                Console.ForegroundColor = ConsoleColor.Blue;
                //switch (op)
                //{
                //    case 1:
                //        var uniqueF = from f in studentF
                //                      group f by new { f.curriculum.Faculty }
                //                      into mygroup
                //                      select mygroup.FirstOrDefault();
                //        foreach (var uF in uniqueF)
                //            Console.WriteLine(uF.curriculum.Faculty);
                //        break;
                //    case 2:
                //        var uniqueS = from s in studentF
                //                      group s by new { s.curriculum.Speciality }
                //                      into mygroup1
                //                      select mygroup1.FirstOrDefault();
                //        foreach (var uS in uniqueS)
                //            Console.WriteLine(uS.curriculum.Speciality);
                //        break;
                //    case 3:
                //        var uniqueC = from c in studentF
                //                      group c by new { c.curriculum.Course }
                //                      into mygroup2
                //                      select mygroup2.FirstOrDefault();
                //        foreach (var uC in uniqueC)
                //            Console.WriteLine(uC.curriculum.Course);
                //        break;
                //    case 4:
                //        var uniqueG = from g in studentF
                //                      group g by new { g.curriculum.Group }
                //                      into mygroup3
                //                      select mygroup3.FirstOrDefault();
                //        foreach (var uG in uniqueG)
                //            Console.WriteLine(uG.curriculum.Group);
                //        break;
                //    default:
                //        throw new Exception("Неверная команда!");
                //}

                switch (op)
                {
                    case 1:
                        var uniqueF = studentF
                            .Select(x => x.curriculum.Faculty).Distinct()
                            .OrderBy(x => x);
                        foreach (var uF in uniqueF)
                            Console.WriteLine(uF);
                        break;
                    case 2:
                        var uniqueS = studentF
                            .Select(x => x.curriculum.Speciality).Distinct()
                            .OrderBy(x => x);
                        foreach (var uS in uniqueS)
                            Console.WriteLine(uS);
                        break;
                    case 3:
                        var uniqueC = studentF
                            .Select(x => x.curriculum.Course).Distinct()
                            .OrderBy(x => x);
                        foreach (var uC in uniqueC)
                            Console.WriteLine(uC);
                        break;
                    case 4:
                        var uniqueG = studentF
                            .Select(x => x.curriculum.Group).Distinct()
                            .OrderBy(x => x);
                        foreach (var uG in uniqueG)
                            Console.WriteLine(uG);
                        break;

                }
                
            }
        }
    }
}
