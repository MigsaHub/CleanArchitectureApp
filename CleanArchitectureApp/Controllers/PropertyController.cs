using CleanArchitectureApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService) {
            _propertyService = propertyService;
        }
        
        [HttpGet("GetProperties")]
        public async Task<IActionResult> Get()
        {
            var properties = await _propertyService.GetAllProperties();

            if (properties.Any()) {
                return Ok(properties);
            }

            return NotFound();
        }
    }
}
