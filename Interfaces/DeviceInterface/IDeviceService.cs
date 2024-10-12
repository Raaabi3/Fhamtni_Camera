using CameraStreamingAPI.DTOs;
using CameraStreamingAPI.Models;

namespace CameraStreamingAPI.Interfaces
{
    public interface IDeviceService
    {
        Task<IEnumerable<Device>> GetAllDevicesAsync();
        Task<Device> CreateDeviceAsync(DeviceDto deviceDto);
    }
}
