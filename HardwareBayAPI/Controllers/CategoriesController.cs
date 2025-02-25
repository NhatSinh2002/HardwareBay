using AutoMapper;
using HardwareBayAPI.Models.Domain;
using HardwareBayAPI.Models.DTO;
using HardwareBayAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HardwareBayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            //Get data from domain model
            var categories = await categoryRepository.GetAllAsync();
            //Map domain model to DTO
            var categoriesDto = mapper.Map<List<CategoryDto>>(categories);
            //foreach (var categoryDomain in categories)
            //{
            //    categoriesDto.Add(new CategoryDto()
            //    {
            //        CategoryID = categoryDomain.CategoryID,
            //        CategoryName = categoryDomain.CategoryName,
            //        Description = categoryDomain.Description,
            //        IsActive = categoryDomain.IsActive
            //    });
            //}
            return Ok(categoriesDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCategoryByID([FromRoute] int id)
        {
            // Get data from domain model
            var category = await categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryDto = mapper.Map<CategoryDto>(category);
            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCategoryRequestDto addCategoryRequestDto)
        {
            //Map DTO to domain model
            var categoryDomain = mapper.Map<Category>(addCategoryRequestDto);
            //create category
            categoryDomain = await categoryRepository.CreateAsync(categoryDomain);
            //Map domain model back to DTO
            var categoryDto = mapper.Map<CategoryDto>(categoryDomain);
            return CreatedAtAction(nameof(GetCategoryByID), new { id = categoryDto.CategoryID }, categoryDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryRequestDto updateCategoryRequestDto)
        {
            //map DTO to domain model
            var categoryDomain = mapper.Map<Category>(updateCategoryRequestDto);
            //check category and update
            categoryDomain = await categoryRepository.UpdateAsync(id,categoryDomain);
            if (categoryDomain == null)
            {
                return NotFound();
            }

            //map domain model to DTO
            var categoryDto = mapper.Map<CategoryDto>(categoryDomain);
            return Ok(categoryDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            //check category and delete
            var categoryDomain = await categoryRepository.DeleteAsync(id);
            if (categoryDomain == null)
            {
                return NotFound();
            }
            //map domain model to DTO
            var categoryDto = mapper.Map<CategoryDto> (categoryDomain);
            return Ok(categoryDto);
        }
    }
}
