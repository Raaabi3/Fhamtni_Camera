using CameraStreamingAPI.DTOs;
using CameraStreamingAPI.Interfaces;
using CameraStreamingAPI.Models;
using CameraStreamingAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CameraStreamingAPI.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhoneService(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        public async Task<IEnumerable<Phone>> GetAllPhoneAsync()
        {
            return await _phoneRepository.GetAllAsync();
        }

        public async Task<Phone> CreatePhoneAsync(PhoneDto phoneDto)
        {
            var phone = new Phone 
            { 
                UserId = phoneDto.UserId, 
                Number = phoneDto.Number, 
                Type = phoneDto.Type, 
            };
            await _phoneRepository.AddAsync(phone);
            return phone;
        }
    }
}
