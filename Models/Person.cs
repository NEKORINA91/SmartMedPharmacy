using System;

namespace SmartMedPharmacy.Models
{
    /// <summary>
    /// Base class representing a person who can log into the system.
    /// Admin and Customer both inherit from this class to avoid
    /// duplicating shared login/identity fields (DRY principle).
    /// </summary>
    public abstract class Person
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        protected Person() { }

        protected Person(string username, string passwordHash, string fullName, string email)
        {
            Username = username;
            PasswordHash = passwordHash;
            FullName = fullName;
            Email = email;
            CreatedAt = DateTime.Now;
        }

        /// Role Check
        public abstract string GetRole();
    }
}
