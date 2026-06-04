using MediatR;
using SmartPOS.Application.DTOs.Inventory.Category;

namespace SmartPOS.Application.Features.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
{
}