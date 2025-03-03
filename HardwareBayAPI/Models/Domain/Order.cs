namespace HardwareBayAPI.Models.Domain
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } // Pending, Paid, Shipped, Delivered, Canceled
        public string ShippingAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string PaymentMethod { get; set; } // "Credit Card", "Paypal", "COD"
        // Navigation properties
        public User User { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        //public ICollection<TransactionLog> TransactionLogs { get; set; }
    }
}
