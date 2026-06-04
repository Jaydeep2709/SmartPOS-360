using MediatR;
using SmartPOS.Application.DTOs.Inventory.Category;

namespace SmartPOS.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<CategoryDto>
{
    public string Name { get; set; }
    public string Description { get; set; }
}