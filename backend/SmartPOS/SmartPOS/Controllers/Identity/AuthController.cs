using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartPOS.Application.DTOs.Identity;
using SmartPOS.Application.Interfaces.Iservices.Identity;
namespace SmartPOS.API.Controllers; 
[ApiController]
[Route("api/[controller]")] 
public class AuthController : ControllerBase
{ 
    private readonly IAuthService _authService; 
    public AuthController(IAuthService authService)
    { 
        _authService = authService;
    } 
    /// <summary> ///
    /// Login User ///
    /// </summary> 
    [HttpPost("login")] 
    [AllowAnonymous] 
    public async Task<IActionResult> Login( [FromBody] LoginDto dto)
    { 
        var result = await _authService.LoginAsync(dto);
        if (result == null) 
        { 
            return Unauthorized(new { message = "Invalid email or password" }); 
        } 
        return Ok(result);
    } 
    /// <summary> 
    /// Refresh Access Token ///
    /// </summary> 
    [HttpPost("refresh-token")]
    [AllowAnonymous] 
    public async Task<IActionResult> RefreshToken( [FromBody] RefreshTokenDto dto)
    { 
        var result = await _authService.RefreshTokenAsync(dto); 
        if (result == null) 
        { 
            return Unauthorized(new { message = "Invalid refresh token" });
        } 
        return Ok(result);
    } 
    /// <summary> 
    /// Logout User ///
    /// </summary> 
    [HttpPost("logout")] 
    [Authorize]
    public IActionResult Logout()
    { 
        return Ok(new { message = "Logout successful" });
    } 
}