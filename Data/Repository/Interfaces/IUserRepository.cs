using DigitalConstructal.Entities;

namespace DigitalConstructal.Data.Repository.Interfaces
{
    public interface IUserRepository : IRepository<UserLogin>
    {
        Task<UserLogin> GetByEmailAsync(string email);
    }
}
