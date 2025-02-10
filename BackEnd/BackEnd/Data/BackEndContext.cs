using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{
  public class BackEndContext : DbContext
  {
    public DbSet<Usuarios> Usuarios { get; set; } = null!;
    public DbSet<Movimientos> Movimientos { get; set; } = null!;
    public DbSet<Productos> Productos { get; set; } = null!;
    public DbSet<Inventario> Inventario { get; set; } = null!;
    public DbSet<TipoMovimiento> TipoMovimiento { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=PruebaDesarrollo;Username=postgres;Password=admin123*;Timeout=10;SslMode=Prefer;");
    }
  }
}
