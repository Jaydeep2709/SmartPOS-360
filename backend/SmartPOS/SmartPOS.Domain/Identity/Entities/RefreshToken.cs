using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Domain.Common;

namespace SmartPOS.Domain.Identity.Entities
{
    public class RefreshToken : BaseEntity
    {
        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string Token { get; set; }

        public DateTime ExpiryDate { get; set; }

        public bool IsRevoked { get; set; }
    }
}
