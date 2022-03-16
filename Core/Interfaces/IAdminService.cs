using dotnet_studies.Core.Models;

namespace dotnet_studies.Core.Interfaces;

public interface IAdminService
{
    Task<bool> AddAsync(Admin admin);
    
    Task<bool> UpdateAsync(Admin admin);
    
    Admin GetById(Guid id);
    
    Admin GetByEmail(string? email);
    
    IEnumerable<Admin> GetAll();

    bool ExistsByEmail(string? email);
}