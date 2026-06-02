using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Application.DTOs.Inventory.PurchaseOrder;

namespace SmartPOS.Application.Interfaces.Iservices.Inventory
{
    public interface IPurchaseOrderService
    {
        Task<IEnumerable<PurchaseOrderDto>> GetAllAsync();

        Task<PurchaseOrderDto?> GetByIdAsync(Guid id);

        Task<PurchaseOrderDto> CreateAsync(CreatePurchaseOrderDto dto);

        Task<bool> UpdateAsync(Guid id,
            UpdatePurchaseOrderDto dto);

        Task<bool> DeleteAsync(Guid id);

        Task<bool> ReceiveAsync(
            ReceivePurchaseOrderDto dto);
    }
}
