using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Student
{
    public class Filter<T>
    {
        public IOrderedEnumerable<T> FSCGFilter(int op) 
        {
            GetFiles files = new GetFiles();
            var sss = files.ReadAllFiles();
                switch (op)
                {
                    case 1:
                        var uniqueF = sss
                            .Select(x => x.curriculum.Faculty).Distinct()
                            .OrderBy(x => x);
                            return (IOrderedEnumerable<T>)uniqueF;                    
                    case 2:
                        var uniqueS = sss
                            .Select(x => x.curriculum.Speciality).Distinct()
                            .OrderBy(x => x);                        
                            return (IOrderedEnumerable<T>)uniqueS;                        
                    case 3:
                        var uniqueC = sss
                            .Select(x => x.curriculum.Course).Distinct()
                            .OrderBy(x => x);                        
                            return (IOrderedEnumerable<T>)uniqueC;                        
                    case 4:
                        var uniqueG = sss
                            .Select(x => x.curriculum.Group).Distinct()
                            .OrderBy(x => x);                        
                            return (IOrderedEnumerable<T>)uniqueG;                    
                    default:
                        throw new Exception();
                }            
                
        }
        public void FilterResult<T>(string op)
        {

        }
    }
}
