using dotnet_studies.Core.Models;

namespace dotnet_studies.Core.Interfaces;

public interface IAuthService
{
    string GenerateToken(Admin admin);

    string Encode(string password);

    bool Verify(string passwordHashed, string password);
}