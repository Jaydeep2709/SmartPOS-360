using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Domain.Common;

namespace SmartPOS.Domain.Reports.Entities
{
    public class SalesReport : BaseEntity
    {
        public DateTime ReportDate { get; set; }

        public decimal TotalSales { get; set; }

        public int TotalOrders { get; set; }

        public int TotalCustomers { get; set; }

        public decimal TotalTax { get; set; }

        public decimal TotalDiscount { get; set; }

        public DateTime GeneratedAt { get; set; }
    }
}
