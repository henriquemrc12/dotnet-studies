using System.Collections.Concurrent;
using System.Net.Http.Headers;
using dotnet_studies.API.Requests;
using dotnet_studies.Core.Interfaces;
using dotnet_studies.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;

namespace dotnet_studies.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CameraController : ControllerBase
{
    private readonly ICameraService _cameraService;

    private static ConcurrentBag<StreamWriter> _clients;

    public CameraController(ICameraService cameraService)
    {
        _cameraService = cameraService;
        _clients = new ConcurrentBag<StreamWriter>();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CameraCreateRequest request)
    {
        if (request == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        Camera newCamera = new Camera(request);
        await _cameraService.AddAsync(newCamera);

        return NoContent();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CameraUpdateRequest request)
    {
        if (request == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        Camera cameraToUpdate = new Camera(request);
        await _cameraService.UpdateAsync(cameraToUpdate);

        return NoContent();
    }
    
    [HttpGet("{id}")]
    public OkObjectResult GetById(Guid id)
    {
        return Ok(_cameraService.GetById(id));
    }
    
    [HttpGet]
    public OkObjectResult GetAll()
    {
        return Ok(_cameraService.GetAll());
    }
}