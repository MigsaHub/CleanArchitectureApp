using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Application.Exceptions;
using CleanArchitectureApp.Application.Services; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService) {
            _propertyService = propertyService;
        }
      
        [HttpPost("CreateProperty")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CreateProperty(PropertyDto request)
        {
            try
            {
                var properties = await _propertyService.CreatePropertyRecord(request);
                return Ok(properties);
               
            }
            catch (Exception ex)
            {
                return BadRequest(new PropertyException(ex.Message, ex.InnerException!));
            }

        }
        [HttpGet("GetProperties")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> Get()
        {
            var properties = await _propertyService.GetAllProperties();

            if (properties.Any())
            {
                return Ok(properties);
            }

            return NotFound();
        }

        [HttpGet("GetPropertiesByUserId")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> GetPropertyByUserId(int userId)
        {
            try
            {
                var properties = await _propertyService.GetPropertiesByUserId(userId);

                if (properties.Any())
                {
                    return Ok(properties);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(new PropertyException(ex.Message, ex.InnerException!));
            }
        }

        [HttpPut("UpdateProperty")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateProperty(PropertyDto request)
        {
            try
            {
                var properties = await _propertyService.UpdatePropertyRecord(request);
                return Ok(properties);

            }
            catch (Exception ex)
            {
                return BadRequest(new PropertyException(ex.Message, ex.InnerException!));
            }

        }


        [HttpDelete("DeletePropertyById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeletePropertyById(int propertyId)
        {
            try
            {
                var properties = await _propertyService.DeletePropertyRecord(propertyId);
                return Ok(properties);

            }
            catch (Exception ex)
            {
                return BadRequest(new PropertyException(ex.Message, ex.InnerException!));
            }

        }


    }
}
