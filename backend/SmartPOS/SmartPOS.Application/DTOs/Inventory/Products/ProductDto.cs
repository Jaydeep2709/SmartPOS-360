using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Application.DTOs.Inventory.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string SKU { get; set; }

        public string Barcode { get; set; }

        public string Description { get; set; }

        public decimal CostPrice { get; set; }

        public decimal SellingPrice { get; set; }

        public bool IsActive { get; set; }
    }
}
