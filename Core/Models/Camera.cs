using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using dotnet_studies.API.Requests;

namespace dotnet_studies.Core.Models;

public class Camera
{
    [Required, Key] public Guid Id { get; set; }

    [Required] public string? Name { get; set; }

    [Required] [MaxLength(50)] public string? Address { get; set; }
    
    [Required] [MaxLength(500)] public string? VideoUrl { get; set; }

    [Column("Updated_At")] public DateTimeOffset UpdatedAt { get; set; }

    [Column("Created_At")] public DateTimeOffset CreatedAt { get; set; }

    public Camera(CameraCreateRequest request)
    {
        Name = request.Name;
        Address = request.Address;
        VideoUrl = request.VideoUrl;
    }
    
    public Camera(CameraUpdateRequest request)
    {
        Id = request.Id;
        Name = request.Name;
        Address = request.Address;
        VideoUrl = request.VideoUrl;
    }

    public Camera()
    {
    }

    public Camera(Guid id, string? name, string? address, string? videoUrl, DateTimeOffset updatedAt, DateTimeOffset createdAt)
    {
        Id = id;
        Name = name;
        Address = address;
        VideoUrl = videoUrl;
        UpdatedAt = updatedAt;
        CreatedAt = createdAt;
    }
}