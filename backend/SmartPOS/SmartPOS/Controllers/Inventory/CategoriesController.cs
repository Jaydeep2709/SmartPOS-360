//using Microsoft.AspNetCore.Mvc;
//using SmartPOS.Application.DTOs.Inventory.Category;
//using SmartPOS.Application.Interfaces.Irepositories.Inventory;
//using SmartPOS.Application.Interfaces.Iservices.Inventory;
//using Microsoft.AspNetCore.Authorization;


//namespace SmartPOS.API.Controllers.Inventory;

//[ApiController]
//[Route("api/[controller]")]
//[Authorize]
//public class CategoriesController : ControllerBase
//{
//    private readonly ICategoryService _service;

//    public CategoriesController(ICategoryService service)
//    {
//        _service = service;
//    }

//    [HttpGet]
//    public async Task<IActionResult> GetAll()
//    {
//        var data = await _service.GetAllAsync();

//        return Ok(data);
//    }

//    [HttpGet("{id}")]
//    public async Task<IActionResult> Get(Guid id)
//    {
//        var data = await _service.GetByIdAsync(id);

//        if (data == null)
//            return NotFound();

//        return Ok(data);
//    }

//    [HttpPost]
//    public async Task<IActionResult> Create(
//        CreateCategoryDto dto)
//    {
//        var data = await _service.CreateAsync(dto);

//        return Ok(data);
//    }

//    [HttpPut("{id}")]
//    public async Task<IActionResult> Update(
//        Guid id,
//        UpdateCategoryDto dto)
//    {
//        var result = await _service.UpdateAsync(id, dto);

//        if (!result)
//            return NotFound();

//        return NoContent();
//    }

//    [HttpDelete("{id}")]
//    public async Task<IActionResult> Delete(Guid id)
//    {
//        var result = await _service.DeleteAsync(id);

//        if (!result)
//            return NotFound();

//        return NoContent();
//    }
//}


using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartPOS.Application.Features.Categories.Commands.CreateCategory;
using SmartPOS.Application.Features.Categories.Commands.UpdateCategory;
using SmartPOS.Application.Features.Categories.Commands.DeleteCategory;
using SmartPOS.Application.Features.Categories.Queries.GetAllCategories;
using SmartPOS.Application.Features.Categories.Queries.GetCategoryById;
using Microsoft.AspNetCore.Authorization;

namespace SmartPOS.API.Controllers.Inventory;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllCategoriesQuery()));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
        => Ok(await _mediator.Send(new GetCategoryByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateCategoryCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteCategoryCommand(id));
        return result ? NoContent() : NotFound();
    }
}