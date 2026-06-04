using AutoMapper;
using SmartPOS.Application.DTOs.Inventory.Category;
using SmartPOS.Domain.Inventory.Entities;

namespace SmartPOS.Application.Mappings;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        // Entity -> DTO
        CreateMap<Category, CategoryDto>();

        // Create DTO -> Entity
        CreateMap<CreateCategoryDto, Category>();

        // Update DTO -> Entity (for patch/update scenarios)
        CreateMap<UpdateCategoryDto, Category>();
    }
}