namespace SmartPOS.Application.DTOs.Identity;

public class UpdateUserDto
{
    public Guid Id { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public string UserName { get; set; }

    public bool IsActive { get; set; }
}