using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Domain.Common;

namespace SmartPOS.Domain.Inventory.Entities
{
    public class Unit : BaseEntity
    {
        public string Name { get; set; }

        public string ShortName { get; set; }
    }
}
