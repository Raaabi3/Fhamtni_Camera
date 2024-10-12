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
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;


        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetDevices()
        {
            var devices = await _deviceService.GetAllDevicesAsync();
            return Ok(devices);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(DeviceDto deviceDto)
        {
            var user = await _deviceService.CreateDeviceAsync(deviceDto);
            return CreatedAtAction(nameof(GetDevices), new { id = user.Id }, user);
        }
    }
}
