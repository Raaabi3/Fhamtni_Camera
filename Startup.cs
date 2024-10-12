using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration; // Add this using directive
using Microsoft.EntityFrameworkCore;
using CameraStreamingAPI.Data;
using CameraStreamingAPI.Repositories;
using CameraStreamingAPI.Services;
using CameraStreamingAPI.Interfaces;
using Microsoft.OpenApi.Models;

namespace CameraStreamingAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration; // Add a private field for IConfiguration

        public Startup(IConfiguration configuration) // Update constructor to accept IConfiguration
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
      {
          c.SwaggerDoc("v1", new OpenApiInfo { Title = "Camera Streaming API", Version = "v1" });
      });
            // Use configuration to get the connection string
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDeviceService, DeviceService>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<IStreamService, StreamService>();
            services.AddScoped<IStreamRepository, StreamRepository>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Camera Streaming API V1");
                c.RoutePrefix = string.Empty; // Set to empty string to serve Swagger UI at the app's root
            });

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
