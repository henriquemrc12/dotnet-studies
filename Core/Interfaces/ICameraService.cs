using dotnet_studies.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_studies.Core.Interfaces;

public interface ICameraService
{
    Task<bool> AddAsync(Camera camera);
    
    Task<bool> UpdateAsync(Camera camera);
    
    Camera GetById(Guid id);
    
    IEnumerable<Camera> GetAll();

    string GetUrlById(Guid id);
}