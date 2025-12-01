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

        builder.Entity<Recogidas>()
        .HasOne(r => r.Empleado)
        .WithMany()
        .HasForeignKey(r => r.EmpleadoId)
        .OnDelete(DeleteBehavior.Restrict); // ?? Cambiar a Restrict

        // Controles - Empleado (NO CASCADE)
        builder.Entity<ControlesCalidad>()
            .HasOne(c => c.Empleado)
            .WithMany()
            .HasForeignKey(c => c.EmpleadoId)
            .OnDelete(DeleteBehavior.Restrict); // ?? Cambiar a Restrict

        // Fermentaciones - Empleado (NO CASCADE)
        builder.Entity<Fermentaciones>()
            .HasOne(f => f.Empleado)
            .WithMany()
            .HasForeignKey(f => f.EmpleadoId)
            .OnDelete(DeleteBehavior.Restrict); // ?? Cambiar a Restrict

        // FermentacionesDetalles - Empleado (NO CASCADE) ?? ESTE ES EL PROBLEMA
        builder.Entity<FermentacionesDetalles>()
            .HasOne(fd => fd.Empleado)
            .WithMany()
            .HasForeignKey(fd => fd.EmpleadoId)
            .OnDelete(DeleteBehavior.Restrict); // ?? Cambiar a Restrict

        // FermentacionesDetalles - Fermentacion (CASCADE está bien)
        builder.Entity<FermentacionesDetalles>()
            .HasOne(fd => fd.Fermentacion)
            .WithMany(f => f.FermentacionesDetalle)
            .HasForeignKey(fd => fd.FermentacionId)
            .OnDelete(DeleteBehavior.Cascade); // ?? Este puede quedar Cascade

        // Pesajes - Empleado (NO CASCADE)
        builder.Entity<Pesajes>()
            .HasOne(p => p.Empleado)
            .WithMany()
            .HasForeignKey(p => p.EmpleadoId)
            .OnDelete(DeleteBehavior.Restrict); // ?? Cambiar a Restrict

        // PesajesDetalles - Empleado (NO CASCADE)
        builder.Entity<PesajesDetalles>()
            .HasOne(pd => pd.Empleado)
            .WithMany()
            .HasForeignKey(pd => pd.EmpleadoId)
            .OnDelete(DeleteBehavior.Restrict); // ?? Cambiar a Restrict

        // PesajesDetalles - Pesaje (CASCADE está bien)
        builder.Entity<PesajesDetalles>()
            .HasOne(pd => pd.Pesaje)
            .WithMany(p => p.PesajesDetalle)
            .HasForeignKey(pd => pd.PesajeId)
            .OnDelete(DeleteBehavior.Cascade); // ?? Este puede quedar Cascade
    }
}
