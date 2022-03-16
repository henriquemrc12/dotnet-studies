using System.ComponentModel.DataAnnotations;

namespace dotnet_studies.API.Requests;

public class CameraCreateRequest
{
    [Required] public string? Name { get; set; }

    [Required] [MaxLength(50)] public string? Address { get; set; }
    
    [Required] [MaxLength(500)] public string? VideoUrl { get; set; }
}