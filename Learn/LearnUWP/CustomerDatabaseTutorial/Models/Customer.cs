using System;

namespace CustomerDatabaseTutorial.Models
{
    public class Customer : IEquatable<Customer>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Company { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public Guid Id { get; set; } = Guid.NewGuid();


        public bool Equals(Customer other)
        {
            return FirstName == other.FirstName
                && LastName == other.LastName
                && Company == other.Company
                && Email == other.Email
                && Phone == other.Phone
                && Address == other.Address;
        }
    }
}