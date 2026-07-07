using System;

namespace SmartMedPharmacy.Models
{
    public class Promotion
    {
        public int      PromoId        { get; set; }
        public string   Code           { get; set; }
        public string   Description    { get; set; }
        public decimal  MinOrderAmount { get; set; }
        public decimal  DiscountAmount { get; set; }
        public DateTime ExpiryDate     { get; set; }
        public bool     IsActive       { get; set; }
        public DateTime CreatedAt      { get; set; }

        public bool IsExpired  => ExpiryDate.Date < DateTime.Today;
        public bool IsValid    => IsActive && !IsExpired;

        // Display string for customer-facing UI
        public string Summary =>
            $"{Code} — Rs. {DiscountAmount:N0} off orders over Rs. {MinOrderAmount:N0}  |  Expires {ExpiryDate:dd MMM yyyy}";
    }
}
