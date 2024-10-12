using CameraStreamingAPI.Data;
using CameraStreamingAPI.Interfaces;
using CameraStreamingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CameraStreamingAPI.Repositories
{
    public class StreamRepository : IStreamRepository
    {
        private readonly AppDbContext _context;

        public StreamRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Stream>> GetAllAsync()
        {
            return await _context.Streams.ToListAsync();
        }

        public async Task AddAsync(Models.Stream stream)
        {
            await _context.Streams.AddAsync(stream);
            await _context.SaveChangesAsync();
        }

        public Models.Stream GetStreamById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddStream(Models.Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}
