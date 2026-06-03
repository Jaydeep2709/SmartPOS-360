using Microsoft.EntityFrameworkCore;
using SmartPOS.Application.Interfaces.IRepositories.Identity;
using SmartPOS.Domain.Identity.Entities;
using SmartPOS.Infrastructure.Data;

namespace SmartPOS.Infrastructure.Repositories.Identity;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly ApplicationDbContext _context;

    public RefreshTokenRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(RefreshToken refreshToken)
    {
        await _context.RefreshToken.AddAsync(refreshToken);

        await _context.SaveChangesAsync();
    }

    public async Task<RefreshToken?> GetByTokenAsync(string token)
    {
        return await _context.RefreshToken
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Token == token);
    }

    public async Task UpdateAsync(RefreshToken refreshToken)
    {
        _context.RefreshToken.Update(refreshToken);

        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<RefreshToken>> GetUserTokensAsync(Guid userId)
    {
        return await _context.RefreshToken
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }
}