using Microsoft.AspNetCore.Identity;
using SmartPOS.Application.DTOs.Identity;
using SmartPOS.Application.Interfaces.Iservices.Identity;
using SmartPOS.Domain.Identity.Entities;
namespace SmartPOS.Application.Services.Identity; 
public class RoleService : IRoleService 
{ 
    private readonly RoleManager<Role> _roleManager; 
    public RoleService(RoleManager<Role> roleManager) 
    { 
        _roleManager = roleManager; 
    } 
    public async Task<IEnumerable<RoleDto>> GetAllAsync() 
    {
        return _roleManager.Roles.Select(x => new RoleDto { Name = x.Name }).ToList(); 
    } 
    public async Task<bool> CreateAsync(CreateRoleDto dto) 
    { 
        if (await _roleManager.RoleExistsAsync(dto.Name))
            return false; 
        var role = new Role { Name = dto.Name }; 
        var result = await _roleManager.CreateAsync(role);
        return result.Succeeded; 
    } 
    public async Task<bool> DeleteAsync(string roleName) 
    { var role = await _roleManager.FindByNameAsync(roleName);
        if (role == null) return false; 
        var result = await _roleManager.DeleteAsync(role);
        return result.Succeeded; 
    } 
}