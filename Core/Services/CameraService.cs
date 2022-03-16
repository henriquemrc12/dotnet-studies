using dotnet_studies.Core.Contexts;
using dotnet_studies.Core.Interfaces;
using dotnet_studies.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_studies.Core.Services;

public class CameraService : ICameraService
{
    private readonly ApplicationDbContext _context;

    public CameraService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> AddAsync(Camera camera)
    {
        camera.UpdatedAt = (DateTimeOffset) DateTime.UtcNow;
        camera.CreatedAt = (DateTimeOffset) DateTime.UtcNow;

        _context.Cameras.Add(camera);

        int saved = await _context.SaveChangesAsync();
        return saved > 0;
    }

    public async Task<bool> UpdateAsync(Camera camera)
    {
        Camera? cameraFounded = _context.Cameras
            .SingleOrDefault(c => c.Id == camera.Id);
        
        if (cameraFounded == null) throw new Exception("Câmera não encontrada");

        cameraFounded.Name = camera.Name;
        cameraFounded.Address = camera.Address;
        cameraFounded.VideoUrl = camera.VideoUrl;
        cameraFounded.UpdatedAt = (DateTimeOffset) DateTime.UtcNow;

        _context.Cameras.Add(camera);

        int saved = await _context.SaveChangesAsync();
        return saved > 0;
    }

    public Camera GetById(Guid id)
    {
        return _context.Cameras
            .First(c => c.Id == id);
    }

    public IEnumerable<Camera> GetAll()
    {
        return _context.Cameras
            .ToArray();
    }

    public string GetUrlById(Guid id)
    {
        Camera cameraFounded = GetById(id);
        
        return cameraFounded.VideoUrl;
    }
}