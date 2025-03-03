using System.ComponentModel.DataAnnotations;

namespace HardwareBayAPI.Models.DTO
{
    public class AddCategoryRequestDto
    {
        [Required]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
