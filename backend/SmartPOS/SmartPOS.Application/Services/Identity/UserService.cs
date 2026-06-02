using Microsoft.AspNetCore.Identity;
using SmartPOS.Application.DTOs.Identity;
using SmartPOS.Application.Interfaces.Iservices.Identity;
using SmartPOS.Domain.Identity.Entities;
namespace SmartPOS.Application.Services.Identity; 
public class UserService : IUserService 
{ 
    private readonly UserManager<ApplicationUser> _userManager; 
    public UserService(UserManager<ApplicationUser> userManager) 
    { 
        _userManager = userManager; 
    } 
    public async Task<IEnumerable<UserDto>> GetAllAsync() 
    { 
        var users = _userManager.Users.ToList(); 
        var result = new List<UserDto>(); 
        foreach (var user in users) 
        { 
            result.Add(new UserDto 
            { 
                Id = user.Id,
                FullName = user.FullName, 
                Email = user.Email,
                UserName = user.UserName,
                IsActive = user.IsActive, 
                Roles = await _userManager.GetRolesAsync(user) 
            }); 
        } 
        return result; 
    } 
    public async Task<UserDto?> GetByIdAsync(Guid id) 
    { 
        var user = await _userManager.FindByIdAsync(id.ToString()); 
        if (user == null) 
            return null;
        return new UserDto 
        { 
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            UserName = user.UserName,
            IsActive = user.IsActive,
            Roles = await _userManager.GetRolesAsync(user) 
        }; 
    } 
    public async Task<UserDto> CreateAsync(CreateUserDto dto)
    { 
        var user = new ApplicationUser 
        { 
            Id = Guid.NewGuid(),
            FullName = dto.FullName,
            Email = dto.Email,
            UserName = dto.UserName,
            IsActive = true 
        }; 
        await _userManager.CreateAsync(user, dto.Password); 
        if (dto.Roles != null) 
        {
            await _userManager.AddToRolesAsync(user, dto.Roles);
        } 
        return new UserDto 
        { 
            Id = user.Id, 
            FullName = user.FullName, 
            Email = user.Email,
            UserName = user.UserName,
            IsActive = user.IsActive,
            Roles = dto.Roles 
        }; 
    } 
    public async Task<bool> UpdateAsync(UpdateUserDto dto) 
    {
        var user = await _userManager.FindByIdAsync(dto.Id.ToString()); 
        if (user == null) 
            return false; 
        user.FullName = dto.FullName;
        user.Email = dto.Email; 
        user.UserName = dto.UserName; 
        user.IsActive = dto.IsActive;
        var result = await _userManager.UpdateAsync(user);
        return result.Succeeded; 
    } 
    public async Task<bool> DeleteAsync(Guid id) 
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user == null) return false; 
        var result = await _userManager.DeleteAsync(user); 
        return result.Succeeded;
    } 
    public async Task<bool> AssignRoleAsync(AssignRoleDto dto) 
    { 
        var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
        if (user == null) 
            return false;
        var result = await _userManager.AddToRoleAsync(user, dto.RoleName);
        return result.Succeeded; 
    } 
}