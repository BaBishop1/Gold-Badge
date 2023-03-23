using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gold_Badge
{
    public class Drivers
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public Drivers() { }
        public Drivers(string firstName, string lastName, int idNumber, string address, string email, int phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public Drivers(string firstName, string lastName, int idNumber, int phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            PhoneNumber = phoneNumber;
        }
    }
}