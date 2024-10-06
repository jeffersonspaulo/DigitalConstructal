using DigitalConstructalWeb.Entities;

namespace DigitalConstructalWeb.Data.Repository.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<List<Project>> GetByTitleAsync(string title);
    }
}
