using AutoMapper;
using HardwareBayAPI.Models.Domain;
using HardwareBayAPI.Models.DTO;

namespace HardwareBayAPI.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Brand,BrandDto>().ReverseMap();
            CreateMap<AddBrandRequestDto, Brand>();
            CreateMap<UpdateBrandRequestDto, Brand>();

            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<AddCategoryRequestDto, Category>();
            CreateMap<UpdateCategoryRequestDto, Category>();

        }
    }
}
