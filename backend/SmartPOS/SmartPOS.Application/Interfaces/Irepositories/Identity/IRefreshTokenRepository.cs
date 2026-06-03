using SmartPOS.Domain.Identity.Entities;

namespace SmartPOS.Application.Interfaces.IRepositories.Identity;

public interface IRefreshTokenRepository
{
    Task AddAsync(RefreshToken refreshToken);

    Task<RefreshToken?> GetByTokenAsync(string token);

    Task UpdateAsync(RefreshToken refreshToken);

    Task<IEnumerable<RefreshToken>> GetUserTokensAsync(Guid userId);
}