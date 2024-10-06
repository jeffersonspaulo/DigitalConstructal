using DigitalConstructalWeb.Data.Repository.Interfaces;
using DigitalConstructalWeb.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalConstructalWeb.Data.Repository
{
    public class ContentRepository : Repository<Content>, IContentRepository
    {
        private readonly DigitalContext _context;

        public ContentRepository(DigitalContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Content>> GetByProjectIdAsync(int projectId)
        {
            return await _context.Contents
                                 .Where(p => p.ProjectId == projectId)
                                 .ToListAsync();
        }
    }
}
