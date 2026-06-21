namespace SmartMedPharmacy.Models
{
    /// <summary>
    /// Represents a customer. Inherits shared identity fields from
    /// Person and adds customer-specific contact details.
    /// </summary>
    public class Customer : Person
    {
        public string Phone { get; set; }
        public string Address { get; set; }

        public Customer() { }

        public Customer(string username, string passwordHash, string fullName,
                         string email, string phone, string address)
            : base(username, passwordHash, fullName, email)
        {
            Phone = phone;
            Address = address;
        }

        public override string GetRole()
        {
            return "Customer";
        }
    }
}
