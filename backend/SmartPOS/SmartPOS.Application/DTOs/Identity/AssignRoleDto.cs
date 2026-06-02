namespace SmartPOS.Application.DTOs.Identity;

public class AssignRoleDto
{
    public Guid UserId { get; set; }

    public string RoleName { get; set; }
}