using CameraStreamingAPI.DTOs;
using CameraStreamingAPI.Models;

namespace CameraStreamingAPI.Interfaces
{
    public interface IPhoneService
    {
        Task<IEnumerable<Phone>> GetAllPhoneAsync();
        Task<Phone> CreatePhoneAsync(PhoneDto deviceDto);
    }
}
