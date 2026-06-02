using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Domain.Common;

namespace SmartPOS.Domain.Inventory.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
