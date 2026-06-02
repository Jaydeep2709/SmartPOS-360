using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Application.DTOs.Inventory.Stock
{
    public class StockAdjustmentDto
    {
        public Guid StockId { get; set; }

        public int Quantity { get; set; }

        public string Reason { get; set; } = string.Empty;

        public string TransactionType { get; set; } = string.Empty;
    }
}
