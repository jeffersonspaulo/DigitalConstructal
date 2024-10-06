using DigitalConstructalWeb.Entities;

namespace DigitalConstructalWeb.Data.Repository.Interfaces
{
    public interface IUserRepository : IRepository<UserLogin>
    {
        Task<UserLogin> GetByEmailAsync(string email);
    }
}
