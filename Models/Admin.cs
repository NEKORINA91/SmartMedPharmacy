namespace SmartMedPharmacy.Models
{
    /// <summary>
    /// Represents a pharmacy admin. Inherits shared identity fields
    /// from Person and adds nothing extra for now, but keeps the
    /// door open for admin-specific fields (e.g. permission level) later.
    /// </summary>
    public class Admin : Person
    {
        public Admin() { }

        public Admin(string username, string passwordHash, string fullName, string email)
            : base(username, passwordHash, fullName, email)
        {
        }

        public override string GetRole()
        {
            return "Admin";
        }
    }
}
