using Furniture_System_Api.Dtos;
using Furniture_System_Api.Models;
using Furniture_System_Api.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Furniture_System_Api.Controllers
{
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
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _productService.GetProduct());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducts(int id)
        {
            return Ok(await _productService.GetProduct(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddProducts(CreateProductRequestDto createProductRequestDto)
        {
            return Ok(await _productService.AddProduct(createProductRequestDto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var success = await _productService.DeleteProduct(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductRequestDto dto)
        {
            var updated = await _productService.UpdateProduct(id, dto);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpGet("componentHierarchy")]
        public async Task<IActionResult> GetHierarchy()
        {
            var result = await _productService.GetProductHierarchy();
            return Ok(result);
        }

        [HttpPost("AddFullProduct")]
        public async Task<IActionResult> AddFullProduct([FromBody] AddFullProductDto dto)
        {
            return Ok(await _productService.AddFullProduct(dto));
        }
    }
}
