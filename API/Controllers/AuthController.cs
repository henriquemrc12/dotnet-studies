using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using dotnet_studies.API.Requests;
using dotnet_studies.Core.Interfaces;
using dotnet_studies.Core.Models;
using dotnet_studies.Core.Services;

namespace dotnet_studies.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    private readonly IAdminService _adminService;
    
    public AuthController(IAuthService authService, IAdminService adminService)
    {
        _authService = authService;
        _adminService = adminService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        Admin admin = _adminService.GetByEmail(request.Email.Trim());
       
        if (admin == null)
            return NotFound(new { message = "Administrador não encontrado" });

        if (!_authService.Verify(admin.Password, request.Password))
            return NotFound(new { message = "Email ou senha inválidos" });

        string token = _authService.GenerateToken(admin);
        return Ok(new {Token = token});
    }
}