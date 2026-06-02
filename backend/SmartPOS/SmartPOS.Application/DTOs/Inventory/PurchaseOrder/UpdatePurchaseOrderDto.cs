using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Application.DTOs.Inventory.PurchaseOrder
{
    public class UpdatePurchaseOrderDto
    {
        public Guid Id { get; set; }

        public DateTime ExpectedDate { get; set; }

        public string Status { get; set; }
    }
}
