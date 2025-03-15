using Microsoft.AspNetCore.Mvc;
using ProductApi.Application.Dtos;
using ProductApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ProductApi.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _productService.GetById(id));
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetAllByPage([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var products = await _productService.GetAllByPage(pageNumber, pageSize);
            return Ok(products);
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboard()
        {
            var result = await _productService.GetDashboard();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ProductDto productDto)
        {
            return Created((await _productService.Create(productDto)).ToString(), productDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductDto productDto)
        {
            await _productService.Update(productDto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _productService.Delete(id);
            return NoContent();
        }
    }
}
