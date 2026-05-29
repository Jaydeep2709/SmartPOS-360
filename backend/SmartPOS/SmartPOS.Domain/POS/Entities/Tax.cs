using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Domain.Common;

namespace SmartPOS.Domain.POS.Entities
{
    public class Tax : BaseEntity
    {
        public string Name { get; set; }

        public decimal Percentage { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
