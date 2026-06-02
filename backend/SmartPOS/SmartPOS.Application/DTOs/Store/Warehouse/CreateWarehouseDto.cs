using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Application.DTOs.Store.Warehouse
{
    public class CreateWarehouseDto
    {
        public Guid BranchId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }
    }
}
