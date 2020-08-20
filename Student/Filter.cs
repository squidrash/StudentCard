using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Student
{
    public class Filter<T>
    {
        List<StudentDTO> studentF = new List<StudentDTO>();

        public IOrderedEnumerable<T> Filter1(int op) 
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

                switch (op)
                {
                    case 1:
                        var uniqueF = studentF
                            .Select(x => x.curriculum.Faculty).Distinct()
                            .OrderBy(x => x);
                            return (IOrderedEnumerable<T>)uniqueF;
                    //foreach (var uF in uniqueF)
                    //    Console.WriteLine(uF);
                    //break;
                    case 2:
                        var uniqueS = studentF
                            .Select(x => x.curriculum.Speciality).Distinct()
                            .OrderBy(x => x);                        
                            return (IOrderedEnumerable<T>)uniqueS;
                        //foreach (var uS in uniqueS)
                        //    Console.WriteLine(uS);
                        //break;
                    case 3:
                        var uniqueC = studentF
                            .Select(x => x.curriculum.Course).Distinct()
                            .OrderBy(x => x);                        
                            return (IOrderedEnumerable<T>)uniqueC;
                        //foreach (var uC in uniqueC)
                        //    Console.WriteLine(uC);
                        //break;
                    case 4:
                        var uniqueG = studentF
                            .Select(x => x.curriculum.Group).Distinct()
                            .OrderBy(x => x);                        
                            return (IOrderedEnumerable<T>)uniqueG;
                    //foreach (var uG in uniqueG)
                    //    Console.WriteLine(uG);
                    //break;
                    default:
                        throw new Exception();
                }
            }
            else
                throw new Exception();
                
        }
        public void FilterResult<T>(string op)
        {

        }
    }
}
