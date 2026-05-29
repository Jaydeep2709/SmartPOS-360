using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Domain.Common;

namespace SmartPOS.Domain.POS.Entities
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int LoyaltyPoints { get; set; }

        public string Address { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
