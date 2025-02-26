using AutoMapper;
using HardwareBayAPI.Models.Domain;
using HardwareBayAPI.Models.DTO;
using HardwareBayAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HardwareBayAPI.Controllers
{
    //https://locahost:portnumber/api/products
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        // GET: https://locahost:portnumber/api/products
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            //get data from domain model
            var products = await productRepository.GetAllAsync();
            //map domain model to DTO
            var productsDto = mapper.Map<List<ProductDto>>(products);
            return Ok(productsDto);
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            //get data from domain model and get product by id
            var product = await productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            //map domain model to DTO
            var productDto = mapper.Map<ProductDto>(product);
            return Ok(productDto);

        }
        

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddProductRequestDto addProductRequestDto)
        {
            //map DTO to domain model
            var productDomain = mapper.Map<Product>(addProductRequestDto);
            productDomain = await productRepository.CreateAsync(productDomain);
            //map domain model to DTO
            var productDto = mapper.Map<ProductDto>(productDomain);
            return CreatedAtAction(nameof(GetById), new { id = productDto.ProductID }, productDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductRequestDto updateProductRequestDto)
        {
            //Map Dto to domain model
            var productDomain= mapper.Map<Product>(updateProductRequestDto);
            productDomain = await productRepository.UpdateAsync(id, productDomain);
            if (productDomain == null)
            { 
                return NotFound();
            }
            // map domain model to DTO
            var productDto = mapper.Map<ProductDto>(productDomain);
            return Ok(productDto);
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var product = await productRepository.DeleteAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
 