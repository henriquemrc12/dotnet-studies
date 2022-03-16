using System.ComponentModel.DataAnnotations;
namespace dotnet_studies.API.Requests;

public class AdminUpdateRequest
{
    [Required] public Guid Id { get; set; }
    
    [Required] [MaxLength(50)] public string? Name { get; set; }

    [Required] [MaxLength(50)] public string? Email { get; set; }
}