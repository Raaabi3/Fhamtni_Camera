using CameraStreamingAPI.Data;
using CameraStreamingAPI.Interfaces;
using CameraStreamingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CameraStreamingAPI.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly AppDbContext _context;

        public DeviceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Device>> GetAllAsync()
        {
            return await _context.Devices.ToListAsync();
        }

        public async Task AddAsync(Device device)
        {
            await _context.Devices.AddAsync(device);
            await _context.SaveChangesAsync();
        }

        public Device GetDeviceById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddDevice(Device device)
        {
            throw new NotImplementedException();
        }
    }
}
