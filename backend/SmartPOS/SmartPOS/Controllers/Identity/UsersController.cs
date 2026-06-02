using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartPOS.Application.DTOs.Identity;
using SmartPOS.Application.Interfaces.Iservices.Identity;
namespace SmartPOS.API.Controllers; 
[ApiController]
[Route("api/[controller]")]
//[Authorize(Roles = "Admin")]
public class UsersController : ControllerBase
{ 
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    { 
        _userService = userService; 
    } 
    /// <summary>
    ///  Get All Users
    ///  </summary> 
   [HttpGet] 
    public async Task<IActionResult> GetAll() 
    { 
        var users = await _userService.GetAllAsync();
        return Ok(users); 
    }
    /// <summary> /// 
    /// Get User By Id /// 
    /// </summary> 
[HttpGet("{id}")] 
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await _userService.GetByIdAsync(id); 
        if (user == null)
        { 
            return NotFound(new { message = "User not found" }); 
        } 
        return Ok(user);
    } 
    /// <summary> ///
    /// Create User /// 
    /// </summary> 
[HttpPost] 
    public async Task<IActionResult> Create( [FromBody] CreateUserDto dto) 
    { 
        var user = await _userService.CreateAsync(dto);
        return Ok(user);
    } 
    /// <summary> /// 
    /// Update User /// 
    /// </summary> 
   [HttpPut("{id}")]
    public async Task<IActionResult> Update( Guid id, [FromBody] UpdateUserDto dto)
    { 
        if (id != dto.Id)
        { 
            return BadRequest(new { message = "Invalid user id" }); 
        } 
        var updated = await _userService.UpdateAsync(dto);
        if (!updated) 
        { 
            return NotFound(new { message = "User not found" });
        }
        return Ok(new { message = "User updated successfully" }); 
    } 
    /// <summary> /// 
    /// Delete User ///
    /// </summary> 
 [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    { 
        var deleted = await _userService.DeleteAsync(id);
        if (!deleted)
        { 
            return NotFound(new { message = "User not found" });
        }
        return Ok(new { message = "User deleted successfully" }); 
    } 
    /// <summary> /// 
    /// Assign Role To User /// 
    /// </summary> 
[HttpPost("assign-role")] 
    public async Task<IActionResult> AssignRole( [FromBody] AssignRoleDto dto)
    { var assigned = await _userService.AssignRoleAsync(dto);
        if (!assigned)
        { 
            return BadRequest(new { message = "Role assignment failed" });
        } 
        return Ok(new { message = "Role assigned successfully" });
    }
}