using Microsoft.EntityFrameworkCore;
using PlantCare.Models;

namespace PlantCare.Persistencia
{
    public class PlantCareContext : DbContext
    {
        public PlantCareContext(DbContextOptions<PlantCareContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Planta> Plantas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("T_PC_USUARIO");
            modelBuilder.Entity<Planta>().ToTable("T_PC_PLANTA");

            modelBuilder.Entity<Planta>().HasKey(p => p.IdPlanta);

            modelBuilder.Entity<Planta>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Plantas)
                .HasForeignKey(p => p.IdUsuario);

            base.OnModelCreating(modelBuilder);
        }
    }
}
