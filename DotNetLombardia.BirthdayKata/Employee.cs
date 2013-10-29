using System;

namespace DotNetLombardia.BirthdayKata
{
    public class Employee
    {
        public Employee(string surname, string name, DateTime birthday, string email)
        {
            Surname = surname;
            Name = name;
            Birthday = birthday;
            Email = email;
        }

        public string Surname { get; private set; }
        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }
        public string Email { get; private set; }
    }
}