namespace HardwareBayAPI.Models.Domain
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        // Navigation properties
        public ICollection<Product> Products { get; set; }
    }
}
