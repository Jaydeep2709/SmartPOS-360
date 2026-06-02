using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartPOS.Application.DTOs.Store.Warehouse;
using SmartPOS.Application.Interfaces.Iservices.Store;

namespace SmartPOS.API.Controllers.Store
{
    [ApiController]
    [Route("api/[controller]")]
    //
    //[Authorize]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseService _service;

        public WarehousesController(IWarehouseService service)
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
            var warehouse = await _service.GetByIdAsync(id);

            if (warehouse == null)
                return NotFound();

            return Ok(warehouse);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWarehouseDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateWarehouseDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var updated = await _service.UpdateAsync(dto);

            if (!updated)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
}
