namespace HardwareBayAPI.Models.DTO
{
    public class UpdateProductRequestDto
    {
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        public decimal Price { get; set; }
        public int? StockQuantity { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
