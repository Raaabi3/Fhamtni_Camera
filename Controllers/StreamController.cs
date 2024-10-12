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
    public class StreamController : ControllerBase
    {
        private readonly IPhoneService _PhoneService;


        public StreamController(IPhoneService PhoneService)
        {
            _PhoneService = PhoneService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetDevices()
        {
            var devices = await _PhoneService.GetAllPhoneAsync();
            return Ok(devices);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(PhoneDto phoneDto)
        {
            var user = await _PhoneService.CreatePhoneAsync(phoneDto);
            return CreatedAtAction(nameof(GetDevices), new { id = user.Id }, user);
        }
    }
}