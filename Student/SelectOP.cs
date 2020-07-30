using System;
using System.Threading.Tasks;

namespace Student
{
    public class SelectOP
    {
        public void Operation(int op)
        {
            switch(op)
            {
                case 1:
                    GetFiles file = new GetFiles();
                    file.Files();
                    break;
                case 2:
                    StudentsInfo student = new StudentsInfo();
                    student.StudentsIf();
                    break;
                case 99:
                    break;
                default:
                    Console.WriteLine("Неверная команда!");
                    break;
            }
        }
    }
}
