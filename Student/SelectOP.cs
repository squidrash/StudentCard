using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student
{
    public class SelectOP
    {
        public object Operation(int op)
        {            
            switch(op)
            {
                case 1:
                    GetFiles file = new GetFiles();
                    var f = file.Files();
                    return f;
                case 2:
                    StudentsInfo student = new StudentsInfo();
                    var s = student.StudentsIf();
                    return s;

                //case 99:
                //    break;
                default:
                    throw new Exception("Неверная команда!");
                    
            }
        }
    }
}
