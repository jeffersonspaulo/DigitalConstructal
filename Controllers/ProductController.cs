using DigitalConstructal.DTOs;
using DigitalConstructal.Services;
using DigitalConstructal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigitalConstructal.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? title, string? description, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var pagedProducts = await _productService.GetPagedProductsAsync(title, description, pageNumber, pageSize);

                return Ok(pagedProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);

                if (product == null) return NotFound();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto productDto)
        {
            try
            {
                await _productService.InsertAsync(productDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDto productDto)
        {
            try
            {
                await _productService.UpdateAsync(id, productDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request." });
            }
        }

        [HttpPost("purchase")]
        public async Task<IActionResult> Purchase()
        {
            return Ok();
        }
    }
}
