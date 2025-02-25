namespace HardwareBayAPI.Models.DTO
{
    public class UpdateCategoryRequestDto
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
