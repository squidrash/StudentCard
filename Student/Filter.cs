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
        //StudentDTO nStudent = new StudentDTO();
        //Dictionary<int, string> nDic = new Dictionary<int, string>();
        //void SetDictionary()
        //{
        //    nDic.Add(1, nStudent.curriculum.Faculty);
        //    nDic.Add(2, nStudent.curriculum.Speciality);
        //    //nDic.Add(3, nStudent.curriculum.Course);
        //    nDic.Add(4, nStudent.curriculum.Group);
        //    dicEx = true;
        //}
        //bool dicEx = false;
        //public IOrderedEnumerable<T> FSCGFilter(int op)
        //{
        //    if(dicEx == false)
        //    {
        //        SetDictionary();
        //    }
        //    var unique = files.ReadAllFiles()
        //        .Where(x => nDic[op])
        //        .OrderBy(x => x);
        //    return (IOrderedEnumerable<T>)unique;
        //}

        public IOrderedEnumerable<T> FSCGFilter(int op)
        {


            switch (op)
            {
                case 1:
                    var uniqueF = files.ReadAllFiles()
                        .Select(x => x.curriculum.Faculty).Distinct()
                        .OrderBy(x => x);
                    return (IOrderedEnumerable<T>)uniqueF;
                case 2:
                    var uniqueS = files.ReadAllFiles()
                        .Select(x => x.curriculum.Speciality).Distinct()
                        .OrderBy(x => x);
                    return (IOrderedEnumerable<T>)uniqueS;
                case 3:
                    var uniqueC = files.ReadAllFiles()
                        .Select(x => x.curriculum.Course).Distinct()
                        .OrderBy(x => x);
                    return (IOrderedEnumerable<T>)uniqueC;
                case 4:
                    var uniqueG = files.ReadAllFiles()
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
            var result = sss.Where(x => x.curriculum.Faculty == s);
            return result;
        }
        public IEnumerable<StudentDTO> FilterS(string s)
        {
            var sss = files.ReadAllFiles();            
            var result = sss.Where(x => x.curriculum.Speciality == s);
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
            var result = sss.Where(x => x.curriculum.Group == s);
            return result;
        }
    }
}
