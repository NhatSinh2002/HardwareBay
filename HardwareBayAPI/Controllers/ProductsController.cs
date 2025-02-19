using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HardwareBayAPI.Controllers
{
    //https://locahost:portnumber/api/products
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: https://locahost:portnumber/api/products
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok();       
        }
    }
}
