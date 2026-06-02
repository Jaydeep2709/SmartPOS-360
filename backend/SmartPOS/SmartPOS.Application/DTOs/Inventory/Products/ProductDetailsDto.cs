using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Application.DTOs.Inventory.Products
{
    public class ProductDetailsDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string SKU { get; set; }

        public string Barcode { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string BrandName { get; set; }

        public string UnitName { get; set; }

        public string SupplierName { get; set; }

        public decimal CostPrice { get; set; }

        public decimal SellingPrice { get; set; }

        public decimal TaxPercentage { get; set; }

        public decimal DiscountPercentage { get; set; }

        public int ReorderLevel { get; set; }

        public bool IsActive { get; set; }
    }
}
