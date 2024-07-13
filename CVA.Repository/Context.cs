using CVA.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVA.Repository
{
    public class Context : DbContext
    {
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Appointment> Appointment { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
