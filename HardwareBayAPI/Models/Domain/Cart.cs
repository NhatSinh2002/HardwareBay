namespace HardwareBayAPI.Models.Domain
{
    public class Cart
    {
        public int CartID { get; set; }
        public int UserID { get; set; }
        public string Status { get; set; } // "Active", "Ordered", "Abandoned"

        public DateTime CreatedDate { get; set; }

        // Navigation properties
        public User User { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
