namespace HardwareBayAPI.Models.DTO
{
    public class BrandDto
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }


        // Navigation properties
        // public ICollection<Product> Products { get; set; }
    }
}
