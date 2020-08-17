using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Student
{
    public class GetFiles
    {
        public IEnumerable<string> Files()
        {
            string dirName = "StudentCards";
            if (Directory.Exists(dirName))
            {
                //string[] files = Directory.GetFiles(dirName);

                var files = Directory.GetFiles(dirName)
                    .Where(x => x.EndsWith(".json"))
                    .Select(x => x.Replace("StudentCards/", ""))
                    .Select(x => x.Replace(".json", ""));
                return files;
                
                //foreach (string s in files)
                //{
                //    Console.WriteLine(s);
                //}
                
            }
            else
            {
                throw new Exception("Несуществует");
            }
        }
        
    }

}
