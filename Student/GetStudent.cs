using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
namespace Student
{
    public class GetStudent
    {
        public async void GetStudentInfo(string js)
        {
            string pathDir = "/Users/nikitarasevskij/Desktop/студенты С#";
            FileInfo fileInf = new FileInfo($"{pathDir}{js}");
            if(fileInf.Exists)
            {
                using (FileStream fs = File.OpenRead($"{pathDir}{js}"))
                {
                    StudentDTO studentDTO = await JsonSerializer.DeserializeAsync<StudentDTO>(fs);
                    Console.WriteLine($"FIO: {studentDTO.FIO},\n Curriculum\nFaculty: {studentDTO.curriculum.Faculty},\nSpeciality: {studentDTO.curriculum.Speciality},\n" +
                    $"Course: {studentDTO.curriculum.Course},\nGpoup: {studentDTO.curriculum.Group},\n Address\nCity: {studentDTO.address.City},\nPostIndex: {studentDTO.address.PostIndex},\n" +
                    $"Street: {studentDTO.address.Street},\n Contact\nPhone: {studentDTO.contact.Phone},\nEmail: {studentDTO.contact.Email}");
                }
            }
        }
    }
}
