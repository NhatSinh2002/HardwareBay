using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace HardwareBayAPI.Models.Domain
{
    public class User
    {
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Role { get; set; } // E.g., "Customer" or "Admin"
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        // Navigation properties
        public ICollection<Order> Orders { get; set; }
        public Cart Cart { get; set; }
        //public Wishlist Wishlist { get; set; }
        //public ICollection<Review> Reviews { get; set; }
    }
}
