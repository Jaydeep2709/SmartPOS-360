using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartPOS.Application.Interfaces.Iservices.Identity;
using SmartPOS.Domain.Identity.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
namespace SmartPOS.Infrastructure.Services.Identity; 
public class TokenService : ITokenService 
{ 
    private readonly IConfiguration _configuration; 
    private readonly UserManager<ApplicationUser> _userManager; 
    public TokenService(IConfiguration configuration, 
        UserManager<ApplicationUser> userManager) 
    { 
        _configuration = configuration; 
        _userManager = userManager; 
    } 
    public async Task<string> GenerateAccessTokenAsync(ApplicationUser user) 
    { 
        var jwtSettings = _configuration.GetSection("JWT"); 
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var roles = await _userManager.GetRolesAsync(user); 
        var claims = new List<Claim> 
        { 
            new Claim(JwtRegisteredClaimNames.Sub,
            user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email,
            user.Email!),
            new Claim(ClaimTypes.Name, user.UserName!)
        }; 
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        var expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["AccessTokenExpirationMinutes"]));
        var token = new JwtSecurityToken
            (
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims, 
            expires: expires, 
            signingCredentials: creds
            ); 
        return new JwtSecurityTokenHandler().WriteToken(token);
    } 
    public string GenerateRefreshToken() 
    { 
        var randomBytes = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);
        return Convert.ToBase64String(randomBytes);
    } 
    public Task<DateTime> GetAccessTokenExpirationAsync()
    { 
        return Task.FromResult(DateTime.UtcNow.AddMinutes(30));
    }
    public Task<bool> ValidateRefreshTokenAsync(ApplicationUser user, string refreshToken) 
    { 
        var token = user.RefreshTokens.FirstOrDefault(x => x.Token == refreshToken && !x.IsRevoked && x.ExpiryDate > DateTime.UtcNow); 
        return Task.FromResult(token != null); 
    } 
}