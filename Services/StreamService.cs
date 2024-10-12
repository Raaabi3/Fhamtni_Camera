using CameraStreamingAPI.DTOs;
using CameraStreamingAPI.Interfaces;
using CameraStreamingAPI.Models;
using CameraStreamingAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CameraStreamingAPI.Services
{
    public class StreamService : IStreamService
    {
        private readonly IStreamRepository _streamRepository;

        public StreamService(IStreamRepository StreamRepository)
        {
            _streamRepository = StreamRepository;
        }

        public async Task<IEnumerable<Models.Stream>> GetAllStreamAsync()
        {
            return await _streamRepository.GetAllAsync();
        }

        public async Task<Models.Stream> CreateStreamAsync(StreamDto streamDto)
        {
            var stream = new Models.Stream 
            { 
                DeviceId = streamDto.DeviceId, 
                StreamUrl = streamDto.StreamUrl, 
                IsActive = streamDto.IsActive, 
                CreatedAt = DateTime.Now
            };
            await _streamRepository.AddAsync(stream);
            return stream;
        }
    }
}
