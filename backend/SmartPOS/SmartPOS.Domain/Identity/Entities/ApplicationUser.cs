using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SmartPOS.Domain.Identity.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
{
    public string FullName { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<RefreshToken> RefreshTokens { get; set; }
}
}
