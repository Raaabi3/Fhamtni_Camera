using CameraStreamingAPI.DTOs;
using CameraStreamingAPI.Interfaces;
using CameraStreamingAPI.Models;
using CameraStreamingAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CameraStreamingAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> CreateUserAsync(UserDto userDto)
        {
            var user = new User 
            { 
                Token = userDto.Token, 
                Name = userDto.Name, 
                Password = userDto.Password, 
                Number = userDto.Number 
            };
            await _userRepository.AddAsync(user);
            return user;
        }
    }
}
