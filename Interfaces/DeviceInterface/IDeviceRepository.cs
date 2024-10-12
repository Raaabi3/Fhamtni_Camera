using CameraStreamingAPI.Models;

namespace CameraStreamingAPI.Interfaces
{
    public interface IDeviceRepository
    {
        Device GetDeviceById(int id);
        void AddDevice(Device device);
        Task<IEnumerable<Device>> GetAllAsync();
        Task AddAsync(Device device);
    }
}
