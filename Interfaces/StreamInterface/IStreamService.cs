using CameraStreamingAPI.DTOs;
using CameraStreamingAPI.Models;

namespace CameraStreamingAPI.Interfaces
{
    public interface IStreamService
    {
        Task<IEnumerable<Models.Stream>> GetAllStreamAsync();
        Task<Models.Stream> CreateStreamAsync(StreamDto streamDto);
    }
}
