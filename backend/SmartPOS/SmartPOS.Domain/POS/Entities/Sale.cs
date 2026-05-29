using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Domain.Common;
using SmartPOS.Domain.Store.Entities;

namespace SmartPOS.Domain.POS.Entities
{
    public class Sale : BaseEntity
    {
        public string InvoiceNumber { get; set; }

        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }

        public Guid BranchId { get; set; }

        public Branch Branch { get; set; }

        public DateTime SaleDate { get; set; }

        public decimal SubTotal { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal ChangeAmount { get; set; }

        public string PaymentStatus { get; set; }

        public string Status { get; set; }

        public ICollection<SaleItem> SaleItems { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}
