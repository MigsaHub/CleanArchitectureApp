﻿using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Application.Exceptions;
using CleanArchitectureApp.Application.Services;
using CleanArchitectureApp.Domain;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<ActionResult<User>> Register(UserDto userDto)
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
      
        [HttpPost("Login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
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

       
        [HttpGet("GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<ActionResult<UserDto>> GetUser(int userId)
        {
            try
            {
                var result = await _userService.GetUser(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new UserServiceException(ex.Message, ex.InnerException!));
            }

        }

      
        [HttpPut("UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<ActionResult<bool>> UpdateUser(UserDto user)
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

       
        [HttpDelete("DeleteUserById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<ActionResult<bool>> DeleteUserById(int userId)
        {
            try
            {
                var result = await _userService.DeleteUser(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new UserServiceException(ex.Message, ex.InnerException!));
            }

        }

       
    }
}
