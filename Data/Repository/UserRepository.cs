using DigitalConstructal.Data.Repository.Interfaces;
using DigitalConstructal.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalConstructal.Data.Repository
{
    public class UserRepository : Repository<UserLogin>, IUserRepository
    {
        private readonly DigitalContext _context;

        public UserRepository(DigitalContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserLogin> GetByEmailAsync(string email)
        {
            return await _context.UserLogins.SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}
