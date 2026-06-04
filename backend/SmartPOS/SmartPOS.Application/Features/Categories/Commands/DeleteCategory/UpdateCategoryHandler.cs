using MediatR;
using Microsoft.Extensions.Logging;
using SmartPOS.Application.Interfaces.Irepositories.Inventory;

namespace SmartPOS.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly ICategoryRepository _repository;
    private readonly ILogger<UpdateCategoryHandler> _logger;

    public UpdateCategoryHandler(ICategoryRepository repository,
        ILogger<UpdateCategoryHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.Id);

        if (category == null)
        {
            _logger.LogWarning(
                "Category not found. CategoryId: {CategoryId}",
                request.Id);

            return false;
        }

        category.Name = request.Name;
        category.Description = request.Description;

        await _repository.UpdateAsync(category);

        _logger.LogInformation(
          "Category updated successfully. CategoryId: {CategoryId}",
          category.Id);

        return true;
    }
}