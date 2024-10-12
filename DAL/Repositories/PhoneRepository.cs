using CameraStreamingAPI.Data;
using CameraStreamingAPI.Interfaces;
using CameraStreamingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CameraStreamingAPI.Repositories
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly AppDbContext _context;

        public PhoneRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Phone>> GetAllAsync()
        {
            return await _context.Phones.ToListAsync();
        }

        public async Task AddAsync(Phone phone)
        {
            await _context.Phones.AddAsync(phone);
            await _context.SaveChangesAsync();
        }

        public Phone GetPhoneById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddPhone(Phone Phone)
        {
            throw new NotImplementedException();
        }
    }
}
