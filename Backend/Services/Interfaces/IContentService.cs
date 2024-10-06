using DigitalConstructalWeb.DTOs;
using DigitalConstructalWeb.Entities;

namespace DigitalConstructalWeb.Services.Interfaces
{
    public interface IContentService
    {
        Task<Content> GetByIdAsync(int id);
        Task<List<Content>> GetByProjectIdAsync(int projectId);
        Task InsertAsync(ContentDto contentDto);
        Task UpdateAsync(int id, ContentDto contentDto);
        Task DeleteAsync(int id);
    }
}
