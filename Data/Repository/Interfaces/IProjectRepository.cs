using DigitalConstructal.Entities;

namespace DigitalConstructal.Data.Repository.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<List<Project>> GetByTitleAsync(string title);
    }
}
