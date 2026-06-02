using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Domain.Inventory.Entities;

namespace SmartPOS.Application.Interfaces.Irepositories.Inventory
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetAllAsync();

        Task<Stock?> GetByIdAsync(Guid id);

        Task<Stock?> GetByProductAndWarehouseAsync(
            Guid productId,
            Guid warehouseId);

        Task AddAsync(Stock stock);

        Task UpdateAsync(Stock stock);

        Task DeleteAsync(Stock stock);
    }
}
