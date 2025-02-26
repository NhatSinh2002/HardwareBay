namespace HardwareBayAPI.Models.DTO
{
    public class ProductDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int? StockQuantity { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? IsActive { get; set; }

        public BrandDto Brand { get; set; }
        public CategoryDto Category { get; set; }
    }
}
