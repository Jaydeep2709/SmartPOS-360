using SmartPOS.Domain.Identity.Entities;
namespace SmartPOS.Application.Interfaces.Iservices.Identity; 

public interface ITokenService 
{ 
    Task<string> GenerateAccessTokenAsync(ApplicationUser user); 
    string GenerateRefreshToken(); Task<DateTime> GetAccessTokenExpirationAsync(); 
    Task<bool> ValidateRefreshTokenAsync(ApplicationUser user, string refreshToken); 
}