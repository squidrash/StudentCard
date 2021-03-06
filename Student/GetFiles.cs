﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Student
{
    public class GetFiles
    {
        List<StudentDTO> studentF = new List<StudentDTO>();
        string dirName = "StudentCards";
        public IEnumerable<string> GetAllFiles()
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
        public List<StudentDTO> ReadAllFiles()
        {
            if (Directory.Exists(dirName))
            {
                var files = Directory.GetFiles(dirName)
                    .Where(x => x.EndsWith(".json"))
                    .Select(x => x.Replace("StudentCards/", ""));
                foreach (var file in files)
                {                    
                    var path = Path.Combine("StudentCards", $"{file}");

                    var jsonString = File.ReadAllText(path);
                    var student = JsonConvert.DeserializeObject<StudentDTO>(jsonString);
                    studentF.Add(student);
                }
                return studentF;
            }
            else
            {
                throw new Exception();
            }
        }
        public StudentDTO GetStudentInfo(string js)
        {
            var filePath = Path.Combine(dirName, js); // объединение составных частей в единый путь с автоматическим разделением /
            FileInfo fileInf = new FileInfo(filePath);
            if (fileInf.Exists)
            {
                var jsonText = File.ReadAllText(filePath);

                var studentDTO = JsonConvert.DeserializeObject<StudentDTO>(jsonText);
                return studentDTO;
            }
            else
            {
                throw new Exception("Файл не существует!");
            }

        }
    }
}
