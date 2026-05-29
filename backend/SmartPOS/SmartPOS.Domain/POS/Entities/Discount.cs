using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Domain.Common;

namespace SmartPOS.Domain.POS.Entities
{
    public class Discount : BaseEntity
    {
        public string Name { get; set; }

        // Percentage or Fixed
        public string Type { get; set; }

        public decimal Value { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
