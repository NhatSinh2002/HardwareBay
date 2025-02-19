namespace HardwareBayAPI.Models.DTO
{
    public class UpdateBrandRequestDto
    {
        public string BrandName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
