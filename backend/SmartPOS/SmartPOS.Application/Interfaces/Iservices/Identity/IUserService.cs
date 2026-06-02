using SmartPOS.Application.DTOs.Identity;

namespace SmartPOS.Application.Interfaces.Iservices.Identity;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();

    Task<UserDto?> GetByIdAsync(Guid id);

    Task<UserDto> CreateAsync(CreateUserDto dto);

    Task<bool> UpdateAsync(UpdateUserDto dto);

    Task<bool> DeleteAsync(Guid id);

    Task<bool> AssignRoleAsync(AssignRoleDto dto);
}