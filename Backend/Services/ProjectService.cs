using AutoMapper;
using DigitalConstructalWeb.Data.Repository.Interfaces;
using DigitalConstructalWeb.DTOs;
using DigitalConstructalWeb.Entities;
using DigitalConstructalWeb.Services.Interfaces;

namespace DigitalConstructalWeb.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _projectRepository.GetAllAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _projectRepository.GetByIdWithIncludesAsync(id, i => i.Contents);
        }

        public async Task<List<Project>> GetByTitleAsync(string title)
        {
            return await _projectRepository.GetByTitleAsync(title);
        }

        public async Task InsertAsync(ProjectDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);

            await _projectRepository.AddAsync(project);
        }

        public async Task UpdateAsync(int id, ProjectDto projectDto)
        {
            var project = await _projectRepository.GetByIdAsync(id);

            if (project == null)
            {
                throw new Exception($"Project with ID {id} not found.");
            }

            project.Title = projectDto.Title;
            project.Briefing = projectDto.Briefing;
            project.Brainstorm = projectDto.Brainstorm;
            project.ContentTypeId = projectDto.ContentTypeId;

            await _projectRepository.UpdateAsync(project);
        }

        public async Task DeleteAsync(int id)
        {
            await _projectRepository.DeleteAsync(id);
        }
    }
}
