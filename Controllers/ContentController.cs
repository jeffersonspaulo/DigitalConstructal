using AutoMapper;
using DigitalConstructal.DTOs;
using DigitalConstructal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigitalConstructal.Controllers
{
    [ApiController]
    [Route("content")]
    public class ContentController : ControllerBase
    {
        private readonly ILogger<ContentController> _logger;
        private readonly IContentService _contentService;
        private readonly IMapper _mapper;

        public ContentController(ILogger<ContentController> logger, IContentService contentService, IMapper mapper)
        {
            _logger = logger;
            _contentService = contentService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContentDto content)
        {
            try
            {
                await _contentService.InsertAsync(content);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while creating the content." });
            }
        }        

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var content = await _contentService.GetByIdAsync(id);

                return Ok(content);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetByProject([FromQuery] int projectId)
        {
            try
            {
                var contents = await _contentService.GetByProjectIdAsync(projectId);

                return Ok(contents);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request." });
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContentDto contentDto)
        {
            try
            {
                await _contentService.UpdateAsync(id, contentDto);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request." });
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _contentService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request." });
            }
        }
    }
}
