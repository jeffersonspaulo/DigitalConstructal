using AutoMapper;
using DigitalConstructal.Data.Repository.Interfaces;
using DigitalConstructal.DTOs;
using DigitalConstructal.Entities;
using DigitalConstructal.Services.Interfaces;

namespace DigitalConstructal.Services
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository _contentRepository;
        private readonly IMapper _mapper;

        public ContentService(IContentRepository contentRepository, IMapper mapper)
        {
            _contentRepository = contentRepository;
            _mapper = mapper;
        }

        public async Task<Content> GetByIdAsync(int id)
        {
            return await _contentRepository.GetByIdWithIncludesAsync(id, i => i.Project);
        }

        public async Task<List<Content>> GetByProjectIdAsync(int projectId)
        {
            return await _contentRepository.GetByProjectIdAsync(projectId);
        }

        public async Task InsertAsync(ContentDto contentDto)
        {
            var content = _mapper.Map<Content>(contentDto);

            await _contentRepository.AddAsync(content);
        }

        public async Task UpdateAsync(int id, ContentDto contentDto)
        {
            var content = await _contentRepository.GetByIdAsync(id);

            if (content == null)
            {
                throw new Exception($"Project with ID {id} not found.");
            }

            content.Title = contentDto.Title;
            content.ProjectId = contentDto.ProjectId;
            content.Body = contentDto.Body;

            await _contentRepository.UpdateAsync(content);
        }

        public async Task DeleteAsync(int id)
        {
            await _contentRepository.DeleteAsync(id);
        }
    }
}
