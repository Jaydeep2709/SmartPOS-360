using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Domain.Store.Entities;

namespace SmartPOS.Application.Interfaces.Irepositories.Store
{
    public interface IWarehouseRepository
    {
        Task<IEnumerable<Warehouse>> GetAllAsync();

        Task<Warehouse?> GetByIdAsync(Guid id);

        Task AddAsync(Warehouse warehouse);

        Task UpdateAsync(Warehouse warehouse);

        Task DeleteAsync(Warehouse warehouse);
    }
}
