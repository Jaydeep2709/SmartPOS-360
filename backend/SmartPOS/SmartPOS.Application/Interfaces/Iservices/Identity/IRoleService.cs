using SmartPOS.Application.DTOs.Identity;

namespace SmartPOS.Application.Interfaces.Iservices.Identity;

public interface IRoleService
{
    Task<IEnumerable<RoleDto>> GetAllAsync();

    Task<bool> CreateAsync(CreateRoleDto dto);

    Task<bool> DeleteAsync(string roleName);
}