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
        
        public IEnumerable<StudentDTO> FilterF(string s)
        {
            var sss = files.ReadAllFiles();
            var faculty = s;
            var result = sss.Where(x => x.curriculum.Faculty == faculty);
            return result;
        }
        public IEnumerable<StudentDTO> FilterS(string s)
        {
            var sss = files.ReadAllFiles();
            var speciality = s;
            var result = sss.Where(x => x.curriculum.Speciality == speciality);
            return result;
        }
        public IEnumerable<StudentDTO> FilterC(string s)
        {
            var sss = files.ReadAllFiles();
            var courseNumber = Int32.Parse(s);
            var result = sss.Where(x => x.curriculum.Course == courseNumber);
            return result;
        }
        public IEnumerable<StudentDTO> FilterG(string s)
        {
            var sss = files.ReadAllFiles();
            var group = s;
            var result = sss.Where(x => x.curriculum.Group == group);
            return result;
        }
    }
}
