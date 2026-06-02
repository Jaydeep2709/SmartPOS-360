using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Application.DTOs.Store.Warehouse
{
    public class UpdateWarehouseDto
    {
        public Guid Id { get; set; }

        public Guid BranchId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }
    }
}
