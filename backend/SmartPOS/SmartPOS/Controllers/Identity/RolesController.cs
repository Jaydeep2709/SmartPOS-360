using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartPOS.Application.DTOs.Identity;
using SmartPOS.Application.Interfaces.Iservices.Identity;
namespace SmartPOS.API.Controllers; [ApiController][Route("api/[controller]")][Authorize(Roles = "Admin")] public class RolesController : ControllerBase { private readonly IRoleService _roleService; public RolesController(IRoleService roleService) { _roleService = roleService; }
    /// <summary> /// Get All Roles /// </summary> 
    [HttpGet] 
    public async Task<IActionResult> GetAll() 
    { 
        var roles = await _roleService.GetAllAsync();
        return Ok(roles); 
    }
    /// <summary> /// Create Role /// </summary> 
    [HttpPost] 
    public async Task<IActionResult> Create( [FromBody] CreateRoleDto dto)
    { 
        var created = await _roleService.CreateAsync(dto);
        if (!created)
        { 
            return BadRequest(new { message = "Role already exists" });
        } return Ok(new { message = "Role created successfully" }); 
    }
    /// <summary> /// Delete Role /// </summary> 
    [HttpDelete("{roleName}")] 
    public async Task<IActionResult> Delete( string roleName)
    {
        var deleted = await _roleService.DeleteAsync(roleName);
        if (!deleted) 
        { 
            return NotFound(new { message = "Role not found" });
        } 
        return Ok(new { message = "Role deleted successfully" }); 
    } 
}