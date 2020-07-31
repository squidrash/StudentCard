using System;
using System.IO;
using System.Linq;

namespace Student
{
    public class GetFiles
    {
        public void Files()
        {
            string dirName = "StudentCards";
            if (Directory.Exists(dirName))
            {
                //string[] files = Directory.GetFiles(dirName);

                var files = Directory.GetFiles(dirName)
                    .Where(x => x.EndsWith(".json"))
                    .Select(x => x.Replace("StudentCards/", ""))
                    .Select(x => x.Replace(".json", ""));


                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }
        }
        
    }

}
