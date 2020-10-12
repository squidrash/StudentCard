using System;
using System.Collections.Generic;
using System.Linq;

namespace Student
{
    public class Filter<T>
    {
        GetFiles files = new GetFiles();
        public IOrderedEnumerable<T> FSCGFilter(int op)
        {
            var dict = new Dictionary<int, Func<StudentDTO, string>>
            {
                { 1, x => x.Curriculum.Faculty},
                { 2, x => x.Curriculum.Speciality },
                //{ 3, x => x.Curriculum.Course },
                { 4, x => x.Curriculum.Group }
            };

            var unique = files.ReadAllFiles()
                        .Select(dict[op])
                        .Distinct()
                        .OrderBy(x => x);
            return (IOrderedEnumerable<T>)unique;

            //switch (op)
            //{
            //    case 1:
            //        var uniqueF = files.ReadAllFiles()
            //            .Select(x => x.Curriculum.Faculty).Distinct()
            //            .OrderBy(x => x);
            //        return (IOrderedEnumerable<T>)uniqueF;
            //    case 2:
            //        var uniqueS = files.ReadAllFiles()
            //            .Select(x => x.Curriculum.Speciality).Distinct()
            //            .OrderBy(x => x);
            //        return (IOrderedEnumerable<T>)uniqueS;
            //    case 3:
            //        var uniqueC = files.ReadAllFiles()
            //            .Select(x => x.Curriculum.Course).Distinct()
            //            .OrderBy(x => x);
            //        return (IOrderedEnumerable<T>)uniqueC;
            //    case 4:
            //        var uniqueG = files.ReadAllFiles()
            //            .Select(x => x.Curriculum.Group).Distinct()
            //            .OrderBy(x => x);
            //        return (IOrderedEnumerable<T>)uniqueG;
            //    default:
            //        throw new Exception();
            //}
        }
        // нужно ли все эти методы объединить в один с помощью словаря?
        public IEnumerable<StudentDTO> FilterF(string inputParam)
        {
            var sss = files.ReadAllFiles();            
            var result = sss.Where(x => x.Curriculum.Faculty == inputParam);
            return result;
        }
        public IEnumerable<StudentDTO> FilterS(string inputParam)
        {
            var sss = files.ReadAllFiles();            
            var result = sss.Where(x => x.Curriculum.Speciality == inputParam);
            return result;
        }
        public IEnumerable<StudentDTO> FilterC(string inputParam)
        {
            var sss = files.ReadAllFiles();
            var courseNumber = Int32.Parse(inputParam);
            var result = sss.Where(x => x.Curriculum.Course == courseNumber);
            return result;
        }
        public IEnumerable<StudentDTO> FilterG(string inputParam)
        {
            var sss = files.ReadAllFiles();            
            var result = sss.Where(x => x.Curriculum.Group == inputParam);
            return result;
        }
    }
}
