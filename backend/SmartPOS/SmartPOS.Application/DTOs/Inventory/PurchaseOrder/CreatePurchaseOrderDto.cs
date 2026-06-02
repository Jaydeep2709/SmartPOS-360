using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Application.DTOs.Inventory.PurchaseOrder
{
    public class CreatePurchaseOrderDto
    {
        public Guid SupplierId { get; set; }

        public DateTime ExpectedDate { get; set; }

        public List<CreatePurchaseOrderItemDto> Items { get; set; }
    }
}
