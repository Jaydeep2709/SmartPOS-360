namespace SmartPOS.Application.DTOs.Identity;

public class ChangePasswordDto
{
    public Guid UserId { get; set; }

    public string CurrentPassword { get; set; }

    public string NewPassword { get; set; }
}