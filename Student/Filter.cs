using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Student
{
    public class Filter<T>
    {
        GetFiles files = new GetFiles();
        public IOrderedEnumerable<T> FSCGFilter(int op) 
        {           
            var RAF = files.ReadAllFiles();
                switch (op)
                {
                    case 1:
                        var uniqueF = RAF
                            .Select(x => x.curriculum.Faculty).Distinct()
                            .OrderBy(x => x);
                            return (IOrderedEnumerable<T>)uniqueF;                    
                    case 2:
                        var uniqueS = RAF
                            .Select(x => x.curriculum.Speciality).Distinct()
                            .OrderBy(x => x);                        
                            return (IOrderedEnumerable<T>)uniqueS;                        
                    case 3:
                        var uniqueC = RAF
                            .Select(x => x.curriculum.Course).Distinct()
                            .OrderBy(x => x);                        
                            return (IOrderedEnumerable<T>)uniqueC;                        
                    case 4:
                        var uniqueG = RAF
                            .Select(x => x.curriculum.Group).Distinct()
                            .OrderBy(x => x);                        
                            return (IOrderedEnumerable<T>)uniqueG;                    
                    default:
                        throw new Exception();
                }            
                
        }
        public void InvokeFilter (int op, string s)
        {
            switch(op)
            {
                case 1:
                    FilterF(s);
                    break;
                case 2:
                    FilterS(s);
                    break;
                case 3:
                    FilterC(s);
                    break;
                case 4:
                    FilterG(s);
                    break;
            }

        }
        public void FilterF(string s)
        { }
        public void FilterS(string s)
        { }
        public void FilterC(string s)
        {
            var sss = files.ReadAllFiles();
            switch(s)
            {
                case "2":
                    var result = sss.Where(x => x.curriculum.Course == 2);
                    foreach (var b in result)
                        //Console.WriteLine(b);
                        Console.WriteLine($"FIO: {b.FIO},\n Curriculum\nFaculty: {b.curriculum.Faculty},\nSpeciality: {b.curriculum.Speciality},\n" +
                        $"Course: {b.curriculum.Course},\nGpoup: {b.curriculum.Group},\n Address\nCity: {b.address.City},\nPostIndex: {b.address.PostIndex},\n" +
                        $"Street: {b.address.Street},\n Contact\nPhone: {b.contact.Phone},\nEmail: {b.contact.Email}");
                    break;
                case "4":
                    result = sss.Where(x => x.curriculum.Course == 4);
                    foreach (var b in result)
                    //Console.WriteLine(b);
                    {
                        Console.WriteLine($"FIO: {b.FIO},\n Curriculum\nFaculty: {b.curriculum.Faculty},\nSpeciality: {b.curriculum.Speciality},\n" +
                          $"Course: {b.curriculum.Course},\nGpoup: {b.curriculum.Group},\n Address\nCity: {b.address.City},\nPostIndex: {b.address.PostIndex},\n" +
                          $"Street: {b.address.Street},\n Contact\nPhone: {b.contact.Phone},\nEmail: {b.contact.Email}");
                        Console.WriteLine();
                    }

                    break;

            }
        }
        public void FilterG(string s)
        { }
    }
}
