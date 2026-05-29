using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Domain.Common;

namespace SmartPOS.Domain.Inventory.Entities
{
    public class Product : BaseEntity
    {
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public Guid BrandId { get; set; }

        public Brand Brand { get; set; }

        public Guid UnitId { get; set; }

        public Unit Unit { get; set; }

        public Guid SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        public string Name { get; set; }

        public string SKU { get; set; }

        public string Barcode { get; set; }

        public string Description { get; set; }

        public decimal CostPrice { get; set; }

        public decimal SellingPrice { get; set; }

        public decimal TaxPercentage { get; set; }

        public decimal DiscountPercentage { get; set; }

        public int ReorderLevel { get; set; }

        public bool IsActive { get; set; } = true;

        public string ProductImageUrl { get; set; }

        public ICollection<ProductVariant> Variants { get; set; }
    }
}
