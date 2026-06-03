using Microsoft.AspNetCore.Identity;
using SmartPOS.Application.DTOs.Identity;
using SmartPOS.Application.Interfaces.IRepositories.Identity;
using SmartPOS.Application.Interfaces.Iservices.Identity;
using SmartPOS.Domain.Identity.Entities;
namespace SmartPOS.Application.Services.Identity;
public class AuthService : IAuthService 
{ 
    private readonly UserManager<ApplicationUser> _userManager; 
    private readonly ITokenService _tokenService;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    public AuthService(UserManager<ApplicationUser> userManager,
                        ITokenService tokenService,
                        IRefreshTokenRepository refreshTokenRepository) 
    { 
        _userManager = userManager; 
        _tokenService = tokenService; 
        _refreshTokenRepository = refreshTokenRepository;
    } 
    public async Task<AuthResponseDto?> LoginAsync(LoginDto dto) 
    { 

        var user = await _userManager.FindByEmailAsync(dto.Email); 
        if (user == null) return null; var validPassword = 
            await _userManager.CheckPasswordAsync(user, dto.Password); 
        if (!validPassword) return null; var accessToken = 
            await _tokenService.GenerateAccessTokenAsync(user); 
        var refreshToken = _tokenService.GenerateRefreshToken();
        await _refreshTokenRepository.AddAsync(
    new RefreshToken
    {
        Id = Guid.NewGuid(),
        UserId = user.Id,
        Token = refreshToken,
        ExpiryDate = DateTime.UtcNow.AddDays(7),
        IsRevoked = false
    });
        //user.RefreshToken.Add(new RefreshToken 
        //{ 
        //    Id = Guid.NewGuid(),
        //    UserId = user.Id,
        //    Token = refreshToken,
        //    ExpiryDate = DateTime.UtcNow.AddDays(7),
        //    IsRevoked = false 
        //});
        var result = await _userManager.UpdateAsync(user);

        Console.WriteLine(result.Succeeded);
        //await _userManager.UpdateAsync(user);
        var roles = await _userManager.GetRolesAsync(user); 
        return new AuthResponseDto 
        { 
            AccessToken = accessToken, 
            RefreshToken = refreshToken,
            Expiration = await _tokenService.GetAccessTokenExpirationAsync(),
            User = new UserDto 
            { 
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email, 
                UserName = user.UserName,
                IsActive = user.IsActive, 
                Roles = roles 
            } 
        }; 
    } 
    public async Task<AuthResponseDto?> RefreshTokenAsync(RefreshTokenDto dto) 
    {
        //var user = _userManager.Users.FirstOrDefault(x => x.RefreshTokens.Any(r => r.Token == dto.RefreshToken));

        var token = await _refreshTokenRepository
                    .GetByTokenAsync(dto.RefreshToken);

        if (token == null)
            return null;

        if (token.IsRevoked)
            return null;

        if (token.ExpiryDate < DateTime.UtcNow)
            return null;

        var user = token.User;
        if (user == null) return null;
        var isValid = await _tokenService.ValidateRefreshTokenAsync(user, dto.RefreshToken);
        if (!isValid) return null;
        var accessToken = await _tokenService.GenerateAccessTokenAsync(user);
        var newRefreshToken = _tokenService.GenerateRefreshToken(); 
        var oldToken = user.RefreshToken.First(x => x.Token == dto.RefreshToken);
        //oldToken.IsRevoked = true; 
        token.IsRevoked = true;

        await _refreshTokenRepository.UpdateAsync(token);

        await _refreshTokenRepository.AddAsync(
        new RefreshToken
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            Token = newRefreshToken,
            ExpiryDate = DateTime.UtcNow.AddDays(7),
            IsRevoked = false
        });
        //user.RefreshTokens.Add(new RefreshToken 
        //{ 
        //    Id = Guid.NewGuid(),
        //    Token = newRefreshToken,
        //    ExpiryDate = DateTime.UtcNow.AddDays(7) 
        //}); 
        //await _userManager.UpdateAsync(user); 
        var roles = await _userManager.GetRolesAsync(user);
        return new AuthResponseDto 
        { 
            AccessToken = accessToken,
            RefreshToken = newRefreshToken,
            Expiration = await _tokenService.GetAccessTokenExpirationAsync(),
            User = new UserDto 
            { 
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                UserName = user.UserName,
                Roles = roles 
            } 
        }; 
    } 
}