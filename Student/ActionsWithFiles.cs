using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

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
            student.Curriculum.Faculty = Console.ReadLine();
            
            Console.WriteLine("Введите специальность");
            student.Curriculum.Speciality = Console.ReadLine();

            Console.WriteLine("Введите курс");
            student.Curriculum.Course = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите группу");
            student.Curriculum.Group = Console.ReadLine();

            Console.WriteLine("Введите город");
            student.Address.City = Console.ReadLine();
            Console.WriteLine("Введите почтовый индекс");

            student.Address.PostIndex = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите улицу");

            student.Address.Street = Console.ReadLine();

            Console.WriteLine("Введите номер телефона");
            student.Contact.Phone = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Введите email");
            student.Contact.Email = Console.ReadLine();


            string dirName = "StudentCards";
            string fileName = $"{student.FIO}.json";
            var filePath = Path.Combine(dirName, fileName);
            var studentJson = JsonConvert.SerializeObject(student);
            File.WriteAllText(filePath, studentJson);
            /*using (FileStream fs = new FileStream($"{filePath}.json", FileMode.OpenOrCreate))
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                await JsonSerializer.SerializeAsync<StudentDTO>(fs,student, options);
            }
            */
            FileInfo fileInf = new FileInfo(filePath);
            if (fileInf.Exists)
            {
                var jsonText = File.ReadAllText(filePath);

                var s = JsonConvert.DeserializeObject<StudentDTO>(jsonText);
                Console.WriteLine($"FIO: {s.FIO},\n Curriculum\nFaculty: {s.Curriculum.Faculty},\nSpeciality: {s.Curriculum.Speciality},\n" +
                        $"Course: {s.Curriculum.Course},\nGpoup: {s.Curriculum.Group},\n Address\nCity: {s.Address.City},\nPostIndex: {s.Address.PostIndex},\n" +
                        $"Street: {s.Address.Street},\n Contact\nPhone: {s.Contact.Phone},\nEmail: {s.Contact.Email}");
            }
        }
        public StudentDTO EditStudent(StudentDTO student)
        {
            var dict = new Dictionary<string, string>
            {
                {"fio", student.FIO},
                {"faculty", student.Curriculum.Faculty},
                {"speciality", student.Curriculum.Speciality},
                //{"course", student.Curriculum.Course },
                {"group", student.Curriculum.Group },
                {"city", student.Address.City },
                //{"postindex", student.Address.PostIndex },
                {"street", student.Address.Street },
                //{"phone", student.Contact.Phone },
                {"email", student.Contact.Email}
            };
            var isProceed = true;
            while(isProceed)
            {
                Console.WriteLine("Что вы хотите изменить?\n" +
                    "FIO\n Curriculum:\n Faculty\tSpeciality\t" +
                    "Course\tGroup\nAddress:\nCity\tPostIndex\tStreet\n" +
                    "Contacts:\nPhone\tEmail ");
                var editableParam = Console.ReadLine();
                Console.WriteLine("Введите значение");
                var sss = Console.ReadLine();
                dict[editableParam] = sss;
                Console.WriteLine(student.FIO);

                Console.WriteLine("Продолжить?");
                var select = Console.ReadLine().ToLower();
                if(select != "да")
                {
                    isProceed = false;
                }
            }
            return student;
        }
    }
}
