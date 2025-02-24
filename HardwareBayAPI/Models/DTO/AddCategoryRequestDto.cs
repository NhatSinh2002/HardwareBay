namespace HardwareBayAPI.Models.DTO
{
    public class AddCategoryRequestDto
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
