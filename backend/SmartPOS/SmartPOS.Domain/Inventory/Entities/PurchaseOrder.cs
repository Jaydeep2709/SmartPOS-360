using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Domain.Common;

namespace SmartPOS.Domain.Inventory.Entities
{
    public class PurchaseOrder : BaseEntity
    {
        public Guid SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ExpectedDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; }

        public ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }
            = new List<PurchaseOrderItem>();
    }
}
