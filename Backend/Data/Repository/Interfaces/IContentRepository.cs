using DigitalConstructalWeb.Entities;

namespace DigitalConstructalWeb.Data.Repository.Interfaces
{
    public interface IContentRepository : IRepository<Content>
    {
        Task<List<Content>> GetByProjectIdAsync(int projectId);
    }
}
