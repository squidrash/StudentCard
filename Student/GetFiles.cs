using System;
using System.IO;

namespace Student
{
    public class GetFIles
    {
        public void Files()
        {
            string dirName = "/Users/nikitarasevskij/Desktop/студенты С#";
            if (Directory.Exists(dirName))
            {
                string[] files = Directory.GetFiles(dirName);
                foreach(string s in files)
                {
                    FileInfo fl = new FileInfo(s);
                    Console.WriteLine(fl.Name);
                }

            }
        }
        
    }

}
