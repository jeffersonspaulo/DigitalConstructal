using AutoMapper;
using DigitalConstructal.DTOs;
using DigitalConstructal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigitalConstructal.Controllers
{
    [ApiController]
    [Route("projects")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(ILogger<ProjectController> logger, IProjectService projectService, IMapper mapper)
        {
            _logger = logger;
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProjectDto project)
        {
            try
            {
                await _projectService.InsertAsync(project);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while creating the project." });
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var projects = await _projectService.GetAllAsync();

                return Ok(projects);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request." });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var project = await _projectService.GetByIdAsync(id);

                return Ok(project);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string title)
        {
            try
            {
                var projects = await _projectService.GetByTitleAsync(title);

                return Ok(projects);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request." });
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProjectDto projectDto)
        {
            try
            {
                await _projectService.UpdateAsync(id, projectDto);

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
                await _projectService.DeleteAsync(id);

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
