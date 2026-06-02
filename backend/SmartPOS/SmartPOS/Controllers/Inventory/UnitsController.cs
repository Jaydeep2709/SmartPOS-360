using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartPOS.Application.DTOs.Inventory.Unit;
using SmartPOS.Application.Interfaces.IServices.Inventory;

namespace SmartPOS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class UnitsController : ControllerBase
{
    private readonly IUnitService _service;

    public UnitsController(IUnitService service)
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
        var unit = await _service.GetByIdAsync(id);

        if (unit == null)
            return NotFound();

        return Ok(unit);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUnitDto dto)
    {
        return Ok(await _service.CreateAsync(dto));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateUnitDto dto)
    {
        if (id != dto.Id)
            return BadRequest();

        var updated = await _service.UpdateAsync(dto);

        if (!updated)
            return NotFound();

        return Ok("Unit Updated Successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return Ok("Unit Deleted Successfully");
    }
}