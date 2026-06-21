using System;
using System.Collections.Generic;

namespace SmartMedPharmacy.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } // Pending, Ready for Pickup, Delivered
        public decimal TotalAmount { get; set; }

        // Not persisted directly - populated when needed for display
        public string CustomerName { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order() { }

        public Order(int customerId)
        {
            CustomerId = customerId;
            OrderDate = DateTime.Now;
            Status = "Pending";
        }
    }

    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int MedicineId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        // Not persisted - for display convenience
        public string MedicineName { get; set; }

        public decimal LineTotal => Quantity * UnitPrice;
    }
}
