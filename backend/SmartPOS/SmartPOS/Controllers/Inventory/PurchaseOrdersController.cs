using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartPOS.Application.DTOs.Inventory.PurchaseOrder;
using SmartPOS.Application.Interfaces.Iservices.Inventory;

namespace SmartPOS.API.Controllers.Inventory;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PurchaseOrdersController : ControllerBase
{
    private readonly IPurchaseOrderService _service;

    public PurchaseOrdersController(
        IPurchaseOrderService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreatePurchaseOrderDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _service.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Id },
            result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        [FromBody] UpdatePurchaseOrderDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _service.UpdateAsync(id, dto);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }

    [HttpPost("receive")]
    public async Task<IActionResult> Receive(
        [FromBody] ReceivePurchaseOrderDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var received = await _service.ReceiveAsync(dto);

        if (!received)
            return BadRequest("Purchase order could not be received.");

        return Ok(new
        {
            Message = "Purchase order received successfully."
        });
    }
}