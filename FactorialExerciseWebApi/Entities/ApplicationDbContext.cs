using FactorialExerciseWebApi.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace FactorialExerciseWebApi.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FactorialValue>().HasIndex(x => x.Value).IsUnique();
            modelBuilder.Entity<FactorialValue>().Property(x => x.Value).IsRequired();
            modelBuilder.Entity<FactorialValue>().HasIndex(x => x.Factorial).IsUnique();
            modelBuilder.Entity<FactorialValue>().Property(x => x.Factorial).IsRequired();
        }

        public DbSet<FactorialValue> FactorialValue { get; set; }
    }
}
