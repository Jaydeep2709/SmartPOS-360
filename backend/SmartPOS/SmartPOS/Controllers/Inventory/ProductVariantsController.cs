using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartPOS.Application.DTOs.Inventory.Product;
using SmartPOS.Application.Interfaces.Iservices.Inventory;

namespace SmartPOS.API.Controllers.Inventory
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class ProductVariantsController : ControllerBase
    {
        private readonly IProductVariantService _service;

        public ProductVariantsController(
            IProductVariantService service)
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
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateProductVariantDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            Guid id,
            UpdateProductVariantDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var updated =
                await _service.UpdateAsync(dto);

            if (!updated)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted =
                await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
}
