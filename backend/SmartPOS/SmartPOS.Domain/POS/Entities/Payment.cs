using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Domain.Common;

namespace SmartPOS.Domain.POS.Entities
{
    public class Payment : BaseEntity
    {
        public Guid SaleId { get; set; }

        public Sale Sale { get; set; }

        public string PaymentMethod { get; set; }

        public decimal Amount { get; set; }

        public string TransactionReference { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}
