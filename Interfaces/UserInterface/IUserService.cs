using CameraStreamingAPI.DTOs;
using CameraStreamingAPI.Models;

namespace CameraStreamingAPI.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> CreateUserAsync(UserDto userDto);
    }
}
