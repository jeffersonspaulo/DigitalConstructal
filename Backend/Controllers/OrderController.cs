using DigitalConstructalWeb.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DigitalConstructalWeb.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        public OrderController() { }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetByCustomer([FromQuery] int customerId)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDto orderDto)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpPut("{id}/status/{orderStatusId}")]
        public async Task<IActionResult> UpdateStatus(int id, int orderStatusId)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }
    }
}
