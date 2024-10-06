using DigitalConstructalWeb.DTOs;
using DigitalConstructalWeb.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DigitalConstructalWeb.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetByTitleAsync(string title);
        Task<PagedResult<Product>> GetPagedProductsAsync(string? title, string? description, int pageNumber, int pageSize);
        Task InsertAsync(ProductDto productDto);
        Task UpdateAsync(int id, ProductDto productDto);
        Task DeleteAsync(int id);
    }
}
