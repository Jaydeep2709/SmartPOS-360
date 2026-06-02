using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using SmartPOS.Application.DTOs.Inventory.Product;
using SmartPOS.Application.DTOs.Inventory.Products;
using SmartPOS.Application.Interfaces.IServices.Inventory;

namespace SmartPOS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
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
        var product = await _service.GetByIdAsync(id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto dto)
    {
        var product = await _service.CreateAsync(dto);

        return Ok(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateProductDto dto)
    {
        if (id != dto.Id)
            return BadRequest();

        var result = await _service.UpdateAsync(dto);

        if (!result)
            return NotFound();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _service.DeleteAsync(id);

        if (!result)
            return NotFound();

        return Ok();
    }
}