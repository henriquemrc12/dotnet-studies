using dotnet_studies.API.Requests;
using dotnet_studies.Core.Interfaces;
using dotnet_studies.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_studies.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    private readonly IAuthService _authService;

    public AdminController(IAdminService adminService, IAuthService authService)
    {
        _adminService = adminService;
        _authService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AdminCreateRequest request)
    {
        if (request == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        request.Password = _authService.Encode(request.Password);

        Admin newAdmin = new Admin(request);
        await _adminService.AddAsync(newAdmin);

        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] AdminUpdateRequest request)
    {
        if (request == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        Admin adminToUpdate = new Admin(request);
        await _adminService.UpdateAsync(adminToUpdate);

        return NoContent();
    }

    [HttpGet("{id}")]
    public OkObjectResult GetById(Guid id)
    {
        return Ok(_adminService.GetById(id));
    }

    [HttpGet]
    public OkObjectResult GetAll()
    {
        return Ok(_adminService.GetAll());
    }

    [HttpGet("exists/{email}")]
    public OkObjectResult ExistsByEmail(string email)
    {
        return Ok(new {Exists = _adminService.ExistsByEmail(email)});
    }
}