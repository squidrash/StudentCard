using System;
namespace Student
{
    public class StudentDTO
    {
        public string FIO { get; set; }
        public Сurriculum curriculum { get; set; }
        public Address address { get; set; }
        public Contacts contact { get; set; }
    }

    public class Сurriculum
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
