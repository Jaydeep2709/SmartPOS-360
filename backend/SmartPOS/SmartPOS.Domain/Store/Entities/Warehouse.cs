using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Domain.Common;
using SmartPOS.Domain.Inventory.Entities;

namespace SmartPOS.Domain.Store.Entities
{
    public class Warehouse : BaseEntity
    {
        public Guid BranchId { get; set; }

        public Branch Branch { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
    }
}
