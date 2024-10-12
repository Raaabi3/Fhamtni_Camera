using CameraStreamingAPI.Models;

namespace CameraStreamingAPI.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        void AddUser(User user);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
    }
}
