using DigitalConstructal.Data.Repository.Interfaces;
using DigitalConstructal.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalConstructal.Data.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly DigitalContext _context;

        public ProjectRepository(DigitalContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetByTitleAsync(string title)
        {
            return await _context.Projects
                                 .Where(p => p.Title.Contains(title))
                                 .ToListAsync();
        }
    }
}
