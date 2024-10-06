using DigitalConstructalWeb.DTOs;
using DigitalConstructalWeb.Entities;

namespace DigitalConstructalWeb.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> UserExistsAsync(string email);
        Task Insert(UserLoginDto userDto);
        Task<UserLogin?> GetByEmail(string email);
    }
}
