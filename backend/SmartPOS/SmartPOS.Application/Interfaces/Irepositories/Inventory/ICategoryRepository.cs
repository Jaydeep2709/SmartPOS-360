using SmartPOS.Domain.Inventory.Entities;

namespace SmartPOS.Application.Interfaces.Irepositories.Inventory
{

    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category?> GetByIdAsync(Guid id);

        Task<Category> AddAsync(Category category);

        Task UpdateAsync(Category category);

        Task DeleteAsync(Category category);

    }
}