using SmartPOS.Domain.Common;

namespace SmartPOS.Domain.Identity.Entities;

public class AuditLog : BaseEntity
{
    public Guid UserId { get; set; }

    public string Action { get; set; }

    public string EntityName { get; set; }

    public string OldValues { get; set; }

    public string NewValues { get; set; }

    public string IpAddress { get; set; }
}