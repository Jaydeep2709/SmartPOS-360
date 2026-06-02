using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Application.DTOs.Inventory.Stock
{
    public class UpdateStockDto
    {
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public int ReservedQuantity { get; set; }
    }
}
