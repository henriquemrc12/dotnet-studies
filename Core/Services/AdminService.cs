using dotnet_studies.Core.Contexts;
using dotnet_studies.Core.Interfaces;
using dotnet_studies.Core.Models;

namespace dotnet_studies.Core.Services;

public class AdminService : IAdminService
{
    private readonly ApplicationDbContext _context;

    public AdminService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(Admin admin)
    {
        admin.UpdatedAt = (DateTimeOffset) DateTime.UtcNow;
        admin.CreatedAt = (DateTimeOffset) DateTime.UtcNow;
        
        _context.Admins.Add(admin);
        
        int saved = await _context.SaveChangesAsync();
        return saved > 0;
    }

    public async Task<bool> UpdateAsync(Admin admin)
    {
        Admin? adminFounded = _context.Admins
            .SingleOrDefault(a => a.Id == admin.Id);

        if (adminFounded == null) throw new Exception("Administrador não encontrado");
        if (adminFounded.Email != null &&
            !adminFounded.Email.Equals(admin.Email?.Trim()))
        {
            bool existsAdminByEmail = ExistsByEmail(admin.Email);
            if (existsAdminByEmail)
                throw new Exception("E-mail já em uso ");
        }
        
        adminFounded.Name = admin.Name;
        adminFounded.Email = admin.Email?.Trim();
        adminFounded.UpdatedAt = (DateTimeOffset) DateTime.UtcNow;
        
        int saved = await _context.SaveChangesAsync();
        return saved > 0;
    }

    public Admin GetById(Guid id)
    {
        return _context.Admins
            .First(a => a.Id == id);
    }

    public Admin GetByEmail(string email)
    {
        return _context.Admins
            .First(a => a.Email == email);
    }
    public IEnumerable<Admin> GetAll()
    {
        return _context.Admins.ToArray();
    }

    public bool ExistsByEmail(string? email)
    {
        return _context.Admins
            .Any(a => a.Email != null && a.Email.Equals(email));
    }
}