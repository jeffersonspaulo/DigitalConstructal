using DigitalConstructal.DTOs;
using DigitalConstructal.Entities;

namespace DigitalConstructal.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> UserExistsAsync(string email);
        Task Insert(UserLoginDto userDto);
        Task<UserLogin?> GetByEmail(string email);
    }
}
