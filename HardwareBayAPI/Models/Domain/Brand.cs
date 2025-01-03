namespace HardwareBayAPI.Models.Domain
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        // Navigation properties
        public ICollection<Product> Products { get; set; }
    }
}
