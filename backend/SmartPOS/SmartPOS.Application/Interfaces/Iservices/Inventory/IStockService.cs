using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Application.DTOs.Inventory.Stock;

namespace SmartPOS.Application.Interfaces.Iservices.Inventory
{
    public interface IStockService
    {
        Task<IEnumerable<StockDto>> GetAllAsync();

        Task<StockDto?> GetByIdAsync(Guid id);

        Task<StockDto> CreateAsync(CreateStockDto dto);

        Task<bool> UpdateAsync(UpdateStockDto dto);

        Task<bool> DeleteAsync(Guid id);

        Task<bool> AdjustStockAsync(
            StockAdjustmentDto dto);
    }
}
