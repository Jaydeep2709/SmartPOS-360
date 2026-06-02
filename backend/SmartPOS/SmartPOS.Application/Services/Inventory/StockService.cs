using SmartPOS.Application.DTOs.Inventory.Stock;
using SmartPOS.Application.Interfaces.Irepositories.Inventory;
using SmartPOS.Application.Interfaces.IRepositories.Inventory;
using SmartPOS.Application.Interfaces.Iservices.Inventory;
using SmartPOS.Application.Interfaces.IServices.Inventory;
using SmartPOS.Domain.Inventory.Entities;

namespace SmartPOS.Application.Services.Inventory;

public class StockService : IStockService
{
    private readonly IStockRepository _repository;

    public StockService(IStockRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<StockDto>> GetAllAsync()
    {
        var stocks = await _repository.GetAllAsync();

        return stocks.Select(x => new StockDto
        {
            Id = x.Id,
            ProductId = x.ProductId,
            WarehouseId = x.WarehouseId,
            Quantity = x.Quantity,
            ReservedQuantity = x.ReservedQuantity
        });
    }

    public async Task<StockDto?> GetByIdAsync(Guid id)
    {
        var stock = await _repository.GetByIdAsync(id);

        if (stock == null)
            return null;

        return new StockDto
        {
            Id = stock.Id,
            ProductId = stock.ProductId,
            WarehouseId = stock.WarehouseId,
            Quantity = stock.Quantity,
            ReservedQuantity = stock.ReservedQuantity
        };
    }

    public async Task<StockDto> CreateAsync(CreateStockDto dto)
    {
        var existingStock =
            await _repository.GetByProductAndWarehouseAsync(
                dto.ProductId,
                dto.WarehouseId);

        if (existingStock != null)
        {
            throw new Exception(
                "Stock already exists for this product in the selected warehouse.");
        }

        var stock = new Stock
        {
            Id = Guid.NewGuid(),
            ProductId = dto.ProductId,
            WarehouseId = dto.WarehouseId,
            Quantity = dto.Quantity,
            ReservedQuantity = dto.ReservedQuantity
        };

        await _repository.AddAsync(stock);

        return new StockDto
        {
            Id = stock.Id,
            ProductId = stock.ProductId,
            WarehouseId = stock.WarehouseId,
            Quantity = stock.Quantity,
            ReservedQuantity = stock.ReservedQuantity
        };
    }

    public async Task<bool> UpdateAsync(UpdateStockDto dto)
    {
        var stock = await _repository.GetByIdAsync(dto.Id);

        if (stock == null)
            return false;

        stock.Quantity = dto.Quantity;
        stock.ReservedQuantity = dto.ReservedQuantity;

        await _repository.UpdateAsync(stock);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var stock = await _repository.GetByIdAsync(id);

        if (stock == null)
            return false;

        await _repository.DeleteAsync(stock);

        return true;
    }

    public async Task<bool> AdjustStockAsync(
        StockAdjustmentDto dto)
    {
        var stock = await _repository.GetByIdAsync(dto.StockId);

        if (stock == null)
            return false;

        stock.Quantity += dto.Quantity;

        if (stock.Quantity < 0)
        {
            throw new Exception(
                "Stock quantity cannot be negative.");
        }

        await _repository.UpdateAsync(stock);

        return true;
    }
}