using CameraStreamingAPI.DTOs;
using CameraStreamingAPI.Interfaces;
using CameraStreamingAPI.Models;
using CameraStreamingAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CameraStreamingAPI.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<IEnumerable<Device>> GetAllDevicesAsync()
        {
            return await _deviceRepository.GetAllAsync();
        }

        public async Task<Device> CreateDeviceAsync(DeviceDto deviceDto)
        {
            var device = new Device 
            { 
                UserId = deviceDto.UserId, 
                DeviceName = deviceDto.DeviceName, 
                DeviceType = deviceDto.DeviceType, 
            };
            await _deviceRepository.AddAsync(device);
            return device;
        }
    }
}
