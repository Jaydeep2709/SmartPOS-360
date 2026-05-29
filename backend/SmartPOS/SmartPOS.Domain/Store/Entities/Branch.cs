using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Domain.Common;

namespace SmartPOS.Domain.Store.Entities
{
    public class Branch : BaseEntity
    {
        public Guid StoreId { get; set; }

        public Store Store { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public ICollection<Warehouse> Warehouses { get; set; }
    }
}
