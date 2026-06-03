using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartPOS.Application.DTOs.Inventory.Stock;
using SmartPOS.Application.Interfaces.Iservices.Inventory;

namespace SmartPOS.API.Controllers.Inventory
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StocksController : ControllerBase
    {
        private readonly IStockService _service;

        public StocksController(IStockService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var stock = await _service.GetByIdAsync(id);

            if (stock == null)
                return NotFound();

            return Ok(stock);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStockDto dto)
        {
            var result = await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            Guid id,
            UpdateStockDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var result = await _service.UpdateAsync(dto);

            return result
                ? NoContent()
                : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAsync(id);

            return result
                ? NoContent()
                : NotFound();
        }
    }
}
