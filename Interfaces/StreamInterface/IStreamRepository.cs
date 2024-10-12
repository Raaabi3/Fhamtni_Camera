using CameraStreamingAPI.Models;

namespace CameraStreamingAPI.Interfaces
{
    public interface IStreamRepository
    {
        Models.Stream GetStreamById(int id);
        void AddStream(Models.Stream stream);
        Task<IEnumerable<Models.Stream>> GetAllAsync();
        Task AddAsync(Models.Stream stream);
    }
}
