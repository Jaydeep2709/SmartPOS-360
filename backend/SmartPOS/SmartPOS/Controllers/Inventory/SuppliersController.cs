using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartPOS.Application.DTOs.Inventory.Supplier;
using SmartPOS.Application.Interfaces.IServices.Inventory;

namespace SmartPOS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class SuppliersController : ControllerBase
{
    private readonly ISupplierService _service;

    public SuppliersController(ISupplierService service)
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
        var supplier = await _service.GetByIdAsync(id);

        if (supplier == null)
            return NotFound();

        return Ok(supplier);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSupplierDto dto)
    {
        return Ok(await _service.CreateAsync(dto));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateSupplierDto dto)
    {
        if (id != dto.Id)
            return BadRequest();

        var updated = await _service.UpdateAsync(dto);

        if (!updated)
            return NotFound();

        return Ok("Supplier Updated Successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return Ok("Supplier Deleted Successfully");
    }
}