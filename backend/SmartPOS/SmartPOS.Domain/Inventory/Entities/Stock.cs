using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Domain.Common;
using SmartPOS.Domain.Store.Entities;

namespace SmartPOS.Domain.Inventory.Entities
{
    public class Stock : BaseEntity
    {
        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public Guid WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }

        public int Quantity { get; set; }

        public int ReservedQuantity { get; set; }
    }
}
