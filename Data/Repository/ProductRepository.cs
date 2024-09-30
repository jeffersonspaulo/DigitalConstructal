using DigitalConstructal.Data.Repository.Interfaces;
using DigitalConstructal.DTOs;
using DigitalConstructal.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalConstructal.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly DigitalContext _context;

        public ProductRepository(DigitalContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetByTitleAsync(string title)
        {
            return await _context.Products
                                 .Where(p => p.Title.Contains(title))
                                 .ToListAsync();
        }

        public async Task<PagedResult<Product>> GetPagedProductsAsync(string? title, string? description, int pageNumber, int pageSize)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(p => p.Title.Contains(title));
            }

            if (!string.IsNullOrEmpty(description))
            {
                query = query.Where(p => p.Description.Contains(description));
            }

            var totalRecords = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Product>
            {
                Items = items,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

    }
}
