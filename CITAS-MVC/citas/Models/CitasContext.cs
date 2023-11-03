using citas.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace citas.Models
{
    public partial class CitasContext : DbContext
    {
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<AlergiaPaciente> AlergiaPaciente { get; set; }
        public DbSet<CitaMedica> CitaMedica { get; set; }

        public CitasContext(DbContextOptions<CitasContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public class CitasContextFactory : IDesignTimeDbContextFactory<CitasContext>
        {
            public CitasContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<CitasContext>();
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=citas;User Id=sa;Password=Passw0rd123@;");

                return new CitasContext(optionsBuilder.Options);
            }
        }
    }
}
