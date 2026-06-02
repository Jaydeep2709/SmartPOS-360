using SmartPOS.Application.DTOs.Inventory.InventoryTransaction;
using SmartPOS.Application.Interfaces.IRepositories.Inventory;
using SmartPOS.Application.Interfaces.IServices.Inventory;
using SmartPOS.Domain.Inventory.Entities;

namespace SmartPOS.Application.Services.Inventory;

public class InventoryTransactionService
    : IInventoryTransactionService
{
    private readonly IInventoryTransactionRepository _repository;

    public InventoryTransactionService(
        IInventoryTransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<InventoryTransactionDto>>
        GetAllAsync()
    {
        var transactions =
            await _repository.GetAllAsync();

        return transactions.Select(x =>
            new InventoryTransactionDto
            {
                Id = x.Id,
                ProductId = x.ProductId,
                TransactionType = x.TransactionType,
                Quantity = x.Quantity,
                ReferenceNumber = x.ReferenceNumber
            });
    }

    public async Task<InventoryTransactionDto?>
        GetByIdAsync(Guid id)
    {
        var transaction =
            await _repository.GetByIdAsync(id);

        if (transaction == null)
            return null;

        return new InventoryTransactionDto
        {
            Id = transaction.Id,
            ProductId = transaction.ProductId,
            TransactionType = transaction.TransactionType,
            Quantity = transaction.Quantity,
            ReferenceNumber = transaction.ReferenceNumber
        };
    }

    public async Task<InventoryTransactionDto>
        CreateAsync(CreateInventoryTransactionDto dto)
    {
        var transaction =
            new InventoryTransaction
            {
                Id = Guid.NewGuid(),
                ProductId = dto.ProductId,
                TransactionType = dto.TransactionType,
                Quantity = dto.Quantity,
                ReferenceNumber = dto.ReferenceNumber
            };

        await _repository.AddAsync(transaction);

        return new InventoryTransactionDto
        {
            Id = transaction.Id,
            ProductId = transaction.ProductId,
            TransactionType = transaction.TransactionType,
            Quantity = transaction.Quantity,
            ReferenceNumber = transaction.ReferenceNumber
        };
    }

    public async Task<bool> UpdateAsync(
        Guid id,
        CreateInventoryTransactionDto dto)
    {
        var transaction =
            await _repository.GetByIdAsync(id);

        if (transaction == null)
            return false;

        transaction.ProductId = dto.ProductId;
        transaction.TransactionType = dto.TransactionType;
        transaction.Quantity = dto.Quantity;
        transaction.ReferenceNumber = dto.ReferenceNumber;

        await _repository.UpdateAsync(transaction);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var transaction =
            await _repository.GetByIdAsync(id);

        if (transaction == null)
            return false;

        await _repository.DeleteAsync(transaction);

        return true;
    }
}