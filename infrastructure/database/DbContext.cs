using Microsoft.EntityFrameworkCore;
using domain.entities;

namespace infrastructure.database;

public class DbContexto : DbContext
{
    private readonly IConfiguration _configurationSettings;
    public DbContexto(IConfiguration configurationSettings)
    {
        _configurationSettings = configurationSettings;
    }

    public DbSet<Admin> Admins { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var stringConnection = _configurationSettings.GetConnectionString("mysql")?.ToString();

        if(!string.IsNullOrEmpty(stringConnection))
        {
            optionsBuilder.UseMySql(
                stringConnection, 
                ServerVersion.AutoDetect(stringConnection)
            );
        }
    }
}

