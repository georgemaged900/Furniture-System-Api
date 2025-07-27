using Furniture_System_Api.Dtos;
using Furniture_System_Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Furniture_System_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentController : ControllerBase
    {
        private readonly IComponentService _componentService;
        public ComponentController(IComponentService componentService)
        {
            _componentService = componentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetComponents()
        {
            return Ok(await _componentService.GetComponent());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComponents(int id)
        {
            return Ok(await _componentService.GetComponent(id));
        }
        [HttpGet("product/{productId}")]
        public async Task<ActionResult> GetComponentsByProduct(int productId)
        {
            return Ok(await _componentService.GetComponentsByProduct(productId));
        }
        [HttpPost]
        public async Task<IActionResult> AddComponents(ComponentDto createComponentRequestDto)
        {
            return Ok(await _componentService.AddComponent(createComponentRequestDto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponent(int id)
        {
            var success = await _componentService.DeleteComponent(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComponent(int id, [FromBody] CreateComponentDto dto)
        {
            var updated = await _componentService.UpdateComponent(id, dto);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }
    }
}
