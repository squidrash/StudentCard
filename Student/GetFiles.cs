using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Student
{
    public class GetFiles
    {
        List<StudentDTO> studentF = new List<StudentDTO>();
        string dirName = "StudentCards";
        public IEnumerable<string> Files()
        {            
            if (Directory.Exists(dirName))
            {
                var files = Directory.GetFiles(dirName)
                    .Where(x => x.EndsWith(".json"))
                    .Select(x => x.Replace("StudentCards/", ""))
                    .Select(x => x.Replace(".json", ""));
                return files;               
            }
            else
            {
                throw new Exception("Несуществует");
            }
        }
        

        
    }

}
