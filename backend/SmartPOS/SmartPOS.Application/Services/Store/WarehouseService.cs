using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Application.DTOs.Store.Warehouse;
using SmartPOS.Application.Interfaces.Irepositories.Store;
using SmartPOS.Application.Interfaces.Iservices.Store;
using SmartPOS.Domain.Store.Entities;

namespace SmartPOS.Application.Services.Store
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _repository;

        public WarehouseService(IWarehouseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<WarehouseDto>> GetAllAsync()
        {
            var warehouses = await _repository.GetAllAsync();

            return warehouses.Select(x => new WarehouseDto
            {
                Id = x.Id,
                BranchId = x.BranchId,
                Name = x.Name,
                Location = x.Location
            });
        }

        public async Task<WarehouseDto?> GetByIdAsync(Guid id)
        {
            var warehouse = await _repository.GetByIdAsync(id);

            if (warehouse == null)
                return null;

            return new WarehouseDto
            {
                Id = warehouse.Id,
                BranchId = warehouse.BranchId,
                Name = warehouse.Name,
                Location = warehouse.Location
            };
        }

        public async Task<WarehouseDto> CreateAsync(CreateWarehouseDto dto)
        {
            var warehouse = new Warehouse
            {
                Id = Guid.NewGuid(),
                BranchId = dto.BranchId,
                Name = dto.Name,
                Location = dto.Location
            };

            await _repository.AddAsync(warehouse);

            return new WarehouseDto
            {
                Id = warehouse.Id,
                BranchId = warehouse.BranchId,
                Name = warehouse.Name,
                Location = warehouse.Location
            };
        }

        public async Task<bool> UpdateAsync(UpdateWarehouseDto dto)
        {
            var warehouse = await _repository.GetByIdAsync(dto.Id);

            if (warehouse == null)
                return false;

            warehouse.BranchId = dto.BranchId;
            warehouse.Name = dto.Name;
            warehouse.Location = dto.Location;

            await _repository.UpdateAsync(warehouse);

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var warehouse = await _repository.GetByIdAsync(id);

            if (warehouse == null)
                return false;

            await _repository.DeleteAsync(warehouse);

            return true;
        }
    }
}
