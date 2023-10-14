using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Application.Exceptions;
using CleanArchitectureApp.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
           _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult<bool>> Register(UserDto userDto)
        { 
            try
            {
                var result = await _userService.Register(userDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new UserServiceException(ex.Message,ex.InnerException!));
            } 

        }

        [HttpGet("GetUserByEmail")]
        public async Task<ActionResult<UserDto>> GetUser(string email)
        {
            try
            {
                var result = await _userService.GetUser(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new UserServiceException(ex.Message, ex.InnerException!));
            }

        }
        
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserDto userDto)
        {
            try
            {
                var result = await _userService.Login(userDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new UserServiceException(ex.Message, ex.InnerException!));
            }

        }

        [HttpPost("DeleteUserByEmail")]
        public async Task<ActionResult<bool>> DeleteUserByEmail(string email)
        {
            try
            {
                var result = await _userService.DeleteUser(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new UserServiceException(ex.Message, ex.InnerException!));
            }

        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<bool>> UpdateUserById(UserDto user)
        {
            try
            {
                var result = await _userService.UpdateUser(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new UserServiceException(ex.Message, ex.InnerException!));
            }

        }
    }
}
