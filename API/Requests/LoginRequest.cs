using System.ComponentModel.DataAnnotations;

namespace dotnet_studies.API.Requests;

public class LoginRequest
{
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
}