using System.ComponentModel.DataAnnotations;

namespace dotnet_studies.API.Requests;

public class AdminCreateRequest
{
    [Required] [MaxLength(50)] public string? Name { get; set; }

    [Required] [MaxLength(50)] public string? Email { get; set; }

    [Required] public string? Password { get; set; }
}