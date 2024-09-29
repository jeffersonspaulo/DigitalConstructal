using DigitalConstructal.DTOs;
using DigitalConstructal.Entities;

namespace DigitalConstructal.Data.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetByTitleAsync(string title);
        Task<PagedResult<Product>> GetPagedProductsAsync(string title, string description, int pageNumber, int pageSize);
    }
}
