using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
          _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<bool>> Register(UserDto request)
        {
            var result = await _userService.Register(request);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
