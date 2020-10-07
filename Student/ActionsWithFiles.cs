using System;
using System.Text.Json;
using System.IO;
namespace Student
{
    public class ActionsWithFiles
    {
        public void AddStudent()
        {
            StudentDTO student = new StudentDTO();

            Console.WriteLine("Введите ФИО студента");
            student.FIO = Console.ReadLine();            

            Console.WriteLine("Введите факультет");
            student.curriculum.Faculty = Console.ReadLine();
            Console.WriteLine(student.curriculum.Faculty);

            Console.WriteLine("Введите специальность");
            student.curriculum.Speciality = Console.ReadLine();

            Console.WriteLine("Введите курс");
            student.curriculum.Course = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите группу");
            student.curriculum.Group = Console.ReadLine();

            Console.WriteLine("Введите город");
            student.address.City = Console.ReadLine();
            Console.WriteLine("Введите почтовый индекс");

            student.address.PostIndex = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите улицу");

            student.address.Street = Console.ReadLine();

            Console.WriteLine("Введите номер телефона");
            student.contact.Phone = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Введите email");
            student.contact.Email = Console.ReadLine();


            string dirName = "StudentCards";
            string fileName = student.FIO;
            var filePath = Path.Combine(dirName, fileName);
            using (FileStream fs = new FileStream($"{filePath}.json", FileMode.CreateNew))
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                JsonSerializer.Serialize<StudentDTO>(student, options);
            }
            using (FileStream fs = File.OpenRead(filePath) )
            {
                var b = JsonSerializer.Deserialize<StudentDTO>(filePath);

                Console.WriteLine($"FIO: {b.FIO},\n Curriculum\nFaculty: {b.curriculum.Faculty},\nSpeciality: {b.curriculum.Speciality},\n" +
                    $"Course: {b.curriculum.Course},\nGpoup: {b.curriculum.Group},\n Address\nCity: {b.address.City},\nPostIndex: {b.address.PostIndex},\n" +
                    $"Street: {b.address.Street},\n Contact\nPhone: {b.contact.Phone},\nEmail: {b.contact.Email}");

            }
        }
    }
}
