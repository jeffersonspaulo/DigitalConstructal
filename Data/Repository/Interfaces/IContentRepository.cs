using DigitalConstructal.Entities;

namespace DigitalConstructal.Data.Repository.Interfaces
{
    public interface IContentRepository : IRepository<Content>
    {
        Task<List<Content>> GetByProjectIdAsync(int projectId);
    }
}
