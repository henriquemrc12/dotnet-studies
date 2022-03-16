using dotnet_studies.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_studies.Core.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        ApplyMigrations(this);
    }

    public DbSet<Admin> Admins { get; set; }
    public DbSet<Camera> Cameras { get; set; }

    public static void ApplyMigrations(ApplicationDbContext context)
    {
        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
    }
}