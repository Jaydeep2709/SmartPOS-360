using SmartPOS.Application.DTOs.Identity;

namespace SmartPOS.Application.Interfaces.Iservices.Identity;

public interface IAuthService
{
    Task<AuthResponseDto?> LoginAsync(LoginDto dto);

    Task<AuthResponseDto?> RefreshTokenAsync(
        RefreshTokenDto dto);
}