using AutoMapper;
using DigitalConstructalWeb.Data.Repository;
using DigitalConstructalWeb.Data.Repository.Interfaces;
using DigitalConstructalWeb.DTOs;
using DigitalConstructalWeb.Entities;
using DigitalConstructalWeb.Services.Interfaces;

namespace DigitalConstructalWeb.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<List<Product>> GetByTitleAsync(string title)
        {
            return await _productRepository.GetByTitleAsync(title);
        }

        public async Task<PagedResult<Product>> GetPagedProductsAsync(string? title, string? description, int pageNumber, int pageSize)
        {
            return await _productRepository.GetPagedProductsAsync(title, description, pageNumber, pageSize);
        }

        public async Task InsertAsync(ProductDto projectDto)
        {
            var project = _mapper.Map<Product>(projectDto);

            await _productRepository.AddAsync(project);
        }

        public async Task UpdateAsync(int id, ProductDto projectDto)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                throw new Exception($"Product with ID {id} not found.");
            }

            product.Title = projectDto.Title;
            product.Description = projectDto.Description;
            product.Price = projectDto.Price;
            product.AssociatedDomain = projectDto.AssociatedDomain;
            product.IncomingBacklink = projectDto.IncomingBacklink;
            product.MonthlyEstimatedTraffic = projectDto.MonthlyEstimatedTraffic;
            product.IndexedPage = projectDto.IndexedPage;
            product.LinkType = projectDto.LinkType;
            product.DomainAuthority = projectDto.DomainAuthority;
            product.PageAuthority = projectDto.PageAuthority;

            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}
