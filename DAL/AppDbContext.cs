using Microsoft.EntityFrameworkCore;
using CameraStreamingAPI.Models;

namespace CameraStreamingAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Phone> Phones { get; set; }

        public DbSet<Models.Stream> Streams { get; set; }



        // Other DbSets for other models (Phones, Devices, etc.) can be added here.
    }
}
