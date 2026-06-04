//using SmartPOS.Application.DTOs.Inventory.Category;
//using SmartPOS.Application.Interfaces.Iservices.Inventory;
//using SmartPOS.Domain.Inventory.Entities;
//using SmartPOS.Application.Interfaces.Irepositories.Inventory;

//namespace SmartPOS.Application.Services.Inventory;

//public class CategoryService : ICategoryService
//{
//    private readonly ICategoryRepository _repository;

//    public CategoryService(ICategoryRepository repository)
//    {
//        _repository = repository;
//    }

//    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
//    {
//        var categories = await _repository.GetAllAsync();

//        return categories.Select(x => new CategoryDto
//        {
//            Id = x.Id,
//            Name = x.Name,
//            Description = x.Description
//        });
//    }

//    public async Task<CategoryDto?> GetByIdAsync(Guid id)
//    {
//        var category = await _repository.GetByIdAsync(id);

//        if (category == null)
//            return null;

//        return new CategoryDto
//        {
//            Id = category.Id,
//            Name = category.Name,
//            Description = category.Description
//        };
//    }

//    public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
//    {
//        var category = new Category
//        {
//            Id = Guid.NewGuid(),
//            Name = dto.Name,
//            Description = dto.Description
//        };

//        await _repository.AddAsync(category);

//        return new CategoryDto
//        {
//            Id = category.Id,
//            Name = category.Name,
//            Description = category.Description
//        };
//    }

//    public async Task<bool> UpdateAsync(Guid id, UpdateCategoryDto dto)
//    {
//        var category = await _repository.GetByIdAsync(id);

//        if (category == null)
//            return false;

//        category.Name = dto.Name;
//        category.Description = dto.Description;

//        await _repository.UpdateAsync(category);

//        return true;
//    }

//    public async Task<bool> DeleteAsync(Guid id)
//    {
//        var category = await _repository.GetByIdAsync(id);

//        if (category == null)
//            return false;

//        await _repository.DeleteAsync(category);

//        return true;
//    }
//}



using AutoMapper;
using SmartPOS.Application.DTOs.Inventory.Category;
using SmartPOS.Application.Interfaces.Irepositories.Inventory;
using SmartPOS.Application.Interfaces.Iservices.Inventory;
using SmartPOS.Domain.Inventory.Entities;

namespace SmartPOS.Application.Services.Inventory;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        var categories = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task<CategoryDto?> GetByIdAsync(Guid id)
    {
        var category = await _repository.GetByIdAsync(id);
        return category == null ? null : _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
    {
        var category = _mapper.Map<Category>(dto);
        category.Id = Guid.NewGuid();

        await _repository.AddAsync(category);

        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateCategoryDto dto)
    {
        var category = await _repository.GetByIdAsync(id);

        if (category == null)
            return false;

        _mapper.Map(dto, category); // updates existing entity

        await _repository.UpdateAsync(category);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var category = await _repository.GetByIdAsync(id);

        if (category == null)
            return false;

        await _repository.DeleteAsync(category);
        return true;
    }
}