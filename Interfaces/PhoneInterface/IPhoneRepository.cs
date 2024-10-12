using CameraStreamingAPI.Models;

namespace CameraStreamingAPI.Interfaces
{
    public interface IPhoneRepository
    {
        Phone GetPhoneById(int id);
        void AddPhone(Phone phone);
        Task<IEnumerable<Phone>> GetAllAsync();
        Task AddAsync(Phone phone);
    }
}
