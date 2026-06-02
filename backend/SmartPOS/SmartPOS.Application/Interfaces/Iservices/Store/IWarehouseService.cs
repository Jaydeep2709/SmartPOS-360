using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Application.DTOs.Store.Warehouse;

namespace SmartPOS.Application.Interfaces.Iservices.Store
{
    public interface IWarehouseService
    {
        Task<IEnumerable<WarehouseDto>> GetAllAsync();

        Task<WarehouseDto?> GetByIdAsync(Guid id);

        Task<WarehouseDto> CreateAsync(CreateWarehouseDto dto);

        Task<bool> UpdateAsync(UpdateWarehouseDto dto);

        Task<bool> DeleteAsync(Guid id);
    }
}
