using System;
namespace Student
{    
    public class StudentDTO
    {
        public StudentDTO()
        {
            Curriculum = new Curriculum();
            Address = new Address();
            Contact = new Contacts();
        }
        public string FIO { get; set; }
        public Curriculum Curriculum { get; set; }
        public Address Address { get; set; }
        public Contacts Contact { get; set; }
    }

    public class Curriculum
    {
        public string Faculty { get; set; }
        public string Speciality { get; set; }
        public int Course { get; set; }
        public string Group { get; set; }
    }
    public class Address
    {
        public string City { get; set; }
        public int PostIndex { get; set; }
        public string Street { get; set; }
    }
    public class Contacts
    {
        public long Phone { get; set; }
        public string Email { get; set; }
    }
    
}
