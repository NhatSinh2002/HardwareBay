using HardwareBayAPI.Data;
using HardwareBayAPI.Models.Domain;
using HardwareBayAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HardwareBayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly HardwareDbContext dbContext;

        public BrandsController(HardwareDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        [HttpGet]
        public IActionResult GetAllBrands()
        {
            // get data from Domain models (Database)
            var brands = dbContext.Brands.ToList();
            // map domain models to DTOs
            var brandsDto = new List<BrandDto>();
            foreach (var brandDomain in brands)
            {
                brandsDto.Add(new BrandDto()
                {
                    BrandID = brandDomain.BrandID,
                    BrandName = brandDomain.BrandName,
                    Description = brandDomain.Description,
                });
            }

            return Ok(brandsDto);
        }



        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetBrandById([FromRoute] int id)
        {
            // get data from Domain models (Database)
            var brandDomain = dbContext.Brands.FirstOrDefault(x => x.BrandID == id);

            if (brandDomain == null)
            {
                return NotFound();
            }
            // map domain models to DTOs
            var brandDto = new BrandDto()
            {
                BrandID = brandDomain.BrandID,
                BrandName = brandDomain.BrandName,
                Description = brandDomain.Description
            };
            return Ok(brandDto);
        }



        [HttpPost]
        public IActionResult Create([FromBody] AddBrandRequestDto addBrandRequestDto)
        {
            // Map DTO to domain models
            var brandDomainModel = new Brand()
            {
                BrandName = addBrandRequestDto.BrandName,
                Description = addBrandRequestDto.Description
            };

            //use domain model to create Brand
            dbContext.Brands.Add(brandDomainModel);
            dbContext.SaveChanges();

            // map domain model back to DTO
            var brandDto = new BrandDto()
            {
                BrandID = brandDomainModel.BrandID,
                BrandName = brandDomainModel.BrandName,
                Description = brandDomainModel.Description
            };

            return CreatedAtAction(nameof(GetBrandById), new { id = brandDto.BrandID }, brandDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateBrandRequestDto updateBrandRequestDto)
        {
            //check if brand exists
            var brandDomainModel = dbContext.Brands.FirstOrDefault(b => b.BrandID == id);
            if (brandDomainModel == null)
            {
                return NotFound();
            }
            //map DTO to domain model
            brandDomainModel.BrandName = updateBrandRequestDto.BrandName;
            brandDomainModel.Description = updateBrandRequestDto.Description;
            brandDomainModel.IsActive = updateBrandRequestDto.IsActive;

            dbContext.SaveChanges();

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
