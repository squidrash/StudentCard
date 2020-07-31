using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
namespace Student
{
    public class GetStudent
    {
        public void GetStudentInfo(string js)
        {
            var filePath = Path.Combine("StudentCards", js); // объединение составных частей в единый путь с автоматическим разделением /
            FileInfo fileInf = new FileInfo(filePath);
            if(fileInf.Exists)
            {
                var jsonText = File.ReadAllText(filePath);
                
                var studentDTO = JsonSerializer.Deserialize<StudentDTO>(jsonText);                
                Console.WriteLine($"FIO: {studentDTO.FIO},\n Curriculum\nFaculty: {studentDTO.curriculum.Faculty},\nSpeciality: {studentDTO.curriculum.Speciality},\n" +
                $"Course: {studentDTO.curriculum.Course},\nGpoup: {studentDTO.curriculum.Group},\n Address\nCity: {studentDTO.address.City},\nPostIndex: {studentDTO.address.PostIndex},\n" +
                $"Street: {studentDTO.address.Street},\n Contact\nPhone: {studentDTO.contact.Phone},\nEmail: {studentDTO.contact.Email}");

            }
        }
    }
}
