using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Domain.Common;
using SmartPOS.Domain.Inventory.Entities;

namespace SmartPOS.Domain.POS.Entities
{
    public class SaleItem : BaseEntity
    {
        public Guid SaleId { get; set; }

        public Sale Sale { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
