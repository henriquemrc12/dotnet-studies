using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using dotnet_studies.API.Requests;

namespace dotnet_studies.Core.Models;

public class Admin
{
    [Required, Key] public Guid Id { get; set; }

    [Required] [MaxLength(50)] public string? Name { get; set; }

    [Required] [MaxLength(50)] public string? Email { get; set; }

    [Required] [JsonIgnore] public string? Password { get; set; }

    [Column("Updated_At")] public DateTimeOffset UpdatedAt { get; set; }

    [Column("Created_At")] public DateTimeOffset CreatedAt { get; set; }

    public Admin(AdminCreateRequest request)
    {
        Name = request.Name;
        Email = request.Email;
        Password = request.Password;
    }
    
    public Admin(AdminUpdateRequest request)
    {
        Id = request.Id;
        Name = request.Name;
        Email = request.Email;
    }

    public Admin()
    {
    }

    public Admin(Guid id, string? name, string? email, string? password, DateTimeOffset createdAt)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        CreatedAt = createdAt;
    }
}