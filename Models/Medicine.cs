using System;

namespace SmartMedPharmacy.Models
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Dosage { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Supplier { get; set; }
        public DateTime CreatedAt { get; set; }

        public Medicine() { }

        public Medicine(string name, string category, string dosage,
                         decimal price, int stockQuantity, string supplier)
        {
            Name = name;
            Category = category;
            Dosage = dosage;
            Price = price;
            StockQuantity = stockQuantity;
            Supplier = supplier;
        }

        /// <summary>
        /// True if stock is low enough to warrant a reorder warning.
        /// Used by the Admin dashboard.
        /// </summary>
        public bool IsLowStock => StockQuantity <= 10;
    }
}
