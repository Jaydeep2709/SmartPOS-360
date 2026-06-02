using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Application.DTOs.Inventory.PurchaseOrder
{
    public class PurchaseOrderDto
    {
        public Guid Id { get; set; }

        public Guid SupplierId { get; set; }

        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ExpectedDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; }

        public ICollection<PurchaseOrderItemDto> Items { get; set; }
    }
}
