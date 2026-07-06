using System;

namespace SmartMedPharmacy.Models
{
    public class Medicine
    {
        public int       MedicineId    { get; set; }
        public string    Name          { get; set; }
        public string    Category      { get; set; }
        public string    Dosage        { get; set; }
        public decimal   Price         { get; set; }
        public int       StockQuantity { get; set; }
        public string    Supplier      { get; set; }
        public DateTime  CreatedAt     { get; set; }
        public DateTime? ExpiryDate    { get; set; }

        // Parameterless constructor (used by DAL MapReader and object initialiser)
        public Medicine() { }

        // Original constructor — kept so existing code still compiles
        public Medicine(string name, string category, string dosage,
                        decimal price, int stockQuantity, string supplier)
        {
            Name          = name;
            Category      = category;
            Dosage        = dosage;
            Price         = price;
            StockQuantity = stockQuantity;
            Supplier      = supplier;
        }

        // True if stock is low enough to warrant a reorder warning
        public bool IsLowStock => StockQuantity <= 10;

        // True if expiry date has passed
        public bool IsExpired =>
            ExpiryDate.HasValue && ExpiryDate.Value.Date < DateTime.Today;

        // True if expiring within 30 days but not yet expired
        public bool IsExpiringSoon =>
            ExpiryDate.HasValue &&
            !IsExpired &&
            ExpiryDate.Value.Date <= DateTime.Today.AddDays(30);
    }
}
