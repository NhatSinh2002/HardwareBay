using AutoMapper;
using HardwareBayAPI.Data;
using HardwareBayAPI.Models.Domain;
using HardwareBayAPI.Models.DTO;
using HardwareBayAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HardwareBayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandRepository brandRepository;
        private readonly IMapper mapper;

        public BrandsController(IBrandRepository brandRepository, IMapper mapper)
        {
            this.brandRepository = brandRepository;
            this.mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            // get data from Domain models (Database)
            var brands = await brandRepository.GetAllAsync();
            // map domain models to DTOs
            //var brandsDto = new List<BrandDto>();
            //foreach (var brandDomain in brands)
            //{
            //    brandsDto.Add(new BrandDto()
            //    {
            //        BrandID = brandDomain.BrandID,
            //        BrandName = brandDomain.BrandName,
            //        Description = brandDomain.Description,
            //        IsActive = brandDomain.IsActive
            //    });
            //}

            // map domain models to DTOs
            var brandsDto= mapper.Map<List<BrandDto>>(brands);

            return Ok(brandsDto);
        }



        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetBrandById([FromRoute] int id)
        {
            // get data from Domain models (Database)
            var brandDomain = await brandRepository.GetByIdAsync(id);

            if (brandDomain == null)
            {
                return NotFound();
            }
            // map domain models to DTOs
            var brandDto = mapper.Map<BrandDto>(brandDomain);
            //var brandDto = new BrandDto()
            //{
            //    BrandID = brandDomain.BrandID,
            //    BrandName = brandDomain.BrandName,
            //    Description = brandDomain.Description, 
            //    IsActive = brandDomain.IsActive
             
            //};
            return Ok(brandDto);
        }



        [HttpPost]
        public async Task <IActionResult >Create([FromBody] AddBrandRequestDto addBrandRequestDto)
        {
            // Map DTO to domain models
            var brandDomain = mapper.Map<Brand>(addBrandRequestDto);
            //var brandDomain = new Brand()
            //{
            //    BrandName = addBrandRequestDto.BrandName,
            //    Description = addBrandRequestDto.Description,
            //    IsActive=addBrandRequestDto.IsActive
            //};

            //use domain model to create Brand
            brandDomain = await brandRepository.CreateAsync(brandDomain);

            // map domain model back to DTO
            var brandDto = mapper.Map<BrandDto>(brandDomain);
            //var brandDto = new BrandDto()
            //{
            //    BrandID = brandDomain.BrandID,
            //    BrandName = brandDomain.BrandName,
            //    Description = brandDomain.Description,
            //    IsActive = brandDomain.IsActive
            //};

            return CreatedAtAction(nameof(GetBrandById), new { id = brandDto.BrandID }, brandDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBrandRequestDto updateBrandRequestDto)
        {
            // map DTO to domain model
            var brandDomain= mapper.Map<Brand>(updateBrandRequestDto);
            //var brandDomain = new Brand
            //{
            //    BrandName = updateBrandRequestDto.BrandName,
            //    Description = updateBrandRequestDto.Description,
            //    IsActive = updateBrandRequestDto.IsActive
            //};

            //check if brand exists
            brandDomain = await brandRepository.UpdateAsync(id, brandDomain);
            if (brandRepository == null)
            {
                return NotFound();
            }

            // map domain model to DTO
            var brandDto=mapper.Map<BrandDto>(brandDomain);
            //var brandDto = new BrandDto()
            //{
            //    BrandID = brandDomain.BrandID,
            //    BrandName = brandDomain.BrandName,
            //    Description = brandDomain.Description,
            //    IsActive = brandDomain.IsActive
            //};
            return Ok(brandDto);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id) {
            
            //check if brand exists
            var brandDomainModel = await brandRepository.DeleteAsync(id);
            if (brandDomainModel == null)
            {
                return NotFound();
            }

            // return deleted brand
            // map domain model to DTO
            var brandDto = new BrandDto()
            {
                BrandID = brandDomainModel.BrandID,
                BrandName = brandDomainModel.BrandName,
                Description = brandDomainModel.Description,
                IsActive = brandDomainModel.IsActive
            };

            return Ok(brandDto);
        }


    }
}
