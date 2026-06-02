using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Domain.Common;
using SmartPOS.Domain.Store.Entities;

namespace SmartPOS.Domain.Inventory.Entities
{
    public class InventoryTransaction : BaseEntity
    {
        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public string TransactionType { get; set; }

        public int Quantity { get; set; }

        public string ReferenceNumber { get; set; }

        public string Remarks { get; set; }
        public Guid WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }

    }
}
