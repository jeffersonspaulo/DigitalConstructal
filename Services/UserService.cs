using AutoMapper;
using DigitalConstructal.Data.Repository.Interfaces;
using DigitalConstructal.DTOs;
using DigitalConstructal.Entities;
using DigitalConstructal.Services.Interfaces;
using BC = BCrypt.Net.BCrypt;

namespace DigitalConstructal.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> UserExistsAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email) != null;
        }

        public async Task Insert(UserLoginDto userDto)
        {
            var user = _mapper.Map<UserLogin>(userDto);

            user.Password = BC.HashPassword(user.Password);

            await _userRepository.AddAsync(user);           
        }

        public async Task<UserLogin?> GetByEmail(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }
    }
}
