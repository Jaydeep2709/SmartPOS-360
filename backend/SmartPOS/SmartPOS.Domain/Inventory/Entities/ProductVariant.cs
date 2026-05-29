using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Domain.Common;

namespace SmartPOS.Domain.Inventory.Entities
{
    public class ProductVariant : BaseEntity
    {
        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public string VariantName { get; set; }

        public string SKU { get; set; }

        public string Barcode { get; set; }

        public decimal SellingPrice { get; set; }

        public decimal CostPrice { get; set; }
    }
}
