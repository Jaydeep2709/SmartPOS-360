using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Application.DTOs.Inventory.InventoryTransaction
{
    public class InventoryTransactionDto
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid WarehouseId { get; set; }

        public string TransactionType { get; set; }

        public int Quantity { get; set; }

        public string ReferenceNumber { get; set; }

        public string Remarks { get; set; }
    }
}
