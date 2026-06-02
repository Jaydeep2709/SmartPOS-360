using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartPOS.Application.DTOs.Inventory.Brand;
using SmartPOS.Application.Interfaces.IServices.Inventory;

namespace SmartPOS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class BrandsController : ControllerBase
{
    private readonly IBrandService _service;

    public BrandsController(IBrandService service)
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
        var brand = await _service.GetByIdAsync(id);

        if (brand == null)
            return NotFound();

        return Ok(brand);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBrandDto dto)
    {
        var brand = await _service.CreateAsync(dto);

        return Ok(brand);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateBrandDto dto)
    {
        if (id != dto.Id)
            return BadRequest();

        var result = await _service.UpdateAsync(dto);

        if (!result)
            return NotFound();

        return Ok(new
        {
            Message = "Brand updated successfully"
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _service.DeleteAsync(id);

        if (!result)
            return NotFound();

        return Ok(new
        {
            Message = "Brand deleted successfully"
        });
    }
}