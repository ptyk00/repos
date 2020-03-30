using System.Data.Entity;

namespace PIV_Lab5
{
    public class TPTContext : DbContext
    {
        public DbSet<Computer> Computers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PC>().ToTable("Pecety");
            modelBuilder.Entity<Laptop>().ToTable("Laptopy");
        }
    }
}