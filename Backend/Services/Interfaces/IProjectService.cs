using DigitalConstructalWeb.DTOs;
using DigitalConstructalWeb.Entities;

namespace DigitalConstructalWeb.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task<List<Project>> GetByTitleAsync(string title);
        Task InsertAsync(ProjectDto projectDto);
        Task UpdateAsync(int id, ProjectDto projectDto);
        Task DeleteAsync(int id);
    }
}
