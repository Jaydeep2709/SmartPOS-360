using SmartPOS.Application.DTOs.Inventory.PurchaseOrder;
using SmartPOS.Application.Interfaces.IRepositories.Inventory;
using SmartPOS.Application.Interfaces.Iservices.Inventory;
using SmartPOS.Application.Interfaces.IServices.Inventory;
using SmartPOS.Domain.Inventory.Entities;
using Microsoft.EntityFrameworkCore;

namespace SmartPOS.Application.Services.Inventory;

public class PurchaseOrderService : IPurchaseOrderService
{
    private readonly IPurchaseOrderRepository _repository;
   

    public PurchaseOrderService(
        IPurchaseOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PurchaseOrderDto>> GetAllAsync()
    {
        var orders = await _repository.GetAllAsync();

        return orders.Select(order => new PurchaseOrderDto
        {
            Id = order.Id,
            SupplierId = order.SupplierId,
            OrderNumber = order.OrderNumber,
            OrderDate = order.OrderDate,
            ExpectedDate = order.ExpectedDate,
            TotalAmount = order.TotalAmount,
            Status = order.Status,
            Items = order.PurchaseOrderItems.Select(item =>
                new PurchaseOrderItemDto
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    TotalPrice = item.TotalPrice
                }).ToList()
        });
    }

    public async Task<PurchaseOrderDto?> GetByIdAsync(Guid id)
    {
        var order = await _repository.GetByIdAsync(id);

        if (order == null)
            return null;

        return new PurchaseOrderDto
        {
            Id = order.Id,
            SupplierId = order.SupplierId,
            OrderNumber = order.OrderNumber,
            OrderDate = order.OrderDate,
            ExpectedDate = order.ExpectedDate,
            TotalAmount = order.TotalAmount,
            Status = order.Status,
            Items = order.PurchaseOrderItems.Select(item =>
                new PurchaseOrderItemDto
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    TotalPrice = item.TotalPrice
                }).ToList()
        };
    }

    public async Task<PurchaseOrderDto> CreateAsync(
        CreatePurchaseOrderDto dto)
    {
        var purchaseOrder = new PurchaseOrder
        {
            Id = Guid.NewGuid(),
            SupplierId = dto.SupplierId,
            OrderNumber = $"PO-{DateTime.UtcNow.Ticks}",
            OrderDate = DateTime.UtcNow,
            ExpectedDate = dto.ExpectedDate,
            Status = "Pending",
            PurchaseOrderItems = new List<PurchaseOrderItem>()
        };

        foreach (var item in dto.Items)
        {
            purchaseOrder.PurchaseOrderItems.Add(
                new PurchaseOrderItem
                {
                    Id = Guid.NewGuid(),
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    TotalPrice = item.Quantity * item.UnitPrice
                });
        }

        purchaseOrder.TotalAmount =
            purchaseOrder.PurchaseOrderItems.Sum(x => x.TotalPrice);

        await _repository.AddAsync(purchaseOrder);

        return await GetByIdAsync(purchaseOrder.Id)
               ?? throw new Exception("Purchase Order creation failed.");
    }

    public async Task<bool> UpdateAsync(
        Guid id,
        UpdatePurchaseOrderDto dto)
    {
        var order = await _repository.GetByIdAsync(id);

        if (order == null)
            return false;

        order.ExpectedDate = dto.ExpectedDate;
        order.Status = dto.Status;
        order.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(order);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var order = await _repository.GetByIdAsync(id);

        if (order == null)
            return false;

        await _repository.DeleteAsync(order);

        return true;
    }

    public async Task<bool> ReceiveAsync(
    ReceivePurchaseOrderDto dto)
    {
        var order =
            await _repository.GetByIdAsync(
                dto.PurchaseOrderId);

        if (order == null)
            return false;

        if (order.Status == "Received")
            return false;

        await _repository.ReceiveAsync(order);

        return true;
    }
}