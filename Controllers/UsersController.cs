using Microsoft.AspNetCore.Mvc;
using CameraStreamingAPI.Models;
using CameraStreamingAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using CameraStreamingAPI.Interfaces;
using CameraStreamingAPI.DTOs;

namespace CameraStreamingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDto userDto)
        {
            var user = await _userService.CreateUserAsync(userDto);
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }
    }
}
