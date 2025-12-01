using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZorzalCacao.Models;

namespace ZorzalCacao.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Recogidas> Recogidas { get; set; }
    public DbSet<Pesajes> Pesajes { get; set; }
    public DbSet<ControlesCalidad> Controles { get; set; }
    public DbSet<Fermentaciones> Fermentaciones { get; set; }
    public DbSet<PesajesDetalles> PesajesDetalles { get; set; }
    public DbSet<Remociones> Remociones { get; set; }
    public DbSet<FermentacionesDetalles> FermentacionesDetalles { get; set; }
    public DbSet<Sacos> Sacos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Relación entre Recogida y ApplicationUser (Productor)
        builder.Entity<Recogidas>()
            .HasOne(r => r.Productor)
            .WithMany() // o WithMany(u => u.Recogidas) si agregas navegación inversa
            .HasForeignKey(r => r.ProductorId)
            .OnDelete(DeleteBehavior.Restrict); // No eliminar recogidas si se borra el usuario
    }
}
