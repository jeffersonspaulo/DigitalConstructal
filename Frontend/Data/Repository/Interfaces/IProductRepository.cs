using DigitalConstructalWeb.DTOs;
using DigitalConstructalWeb.Entities;

namespace DigitalConstructalWeb.Data.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetByTitleAsync(string title);
        Task<PagedResult<Product>> GetPagedProductsAsync(string? title, string? description, int pageNumber, int pageSize);
    }
}
