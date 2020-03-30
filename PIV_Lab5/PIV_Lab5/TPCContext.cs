using System.Data.Entity;

namespace PIV_Lab5
{
    public class TPCContext : DbContext
    {
        public DbSet<Computer> Computers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PC>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("PCs");
            });

            modelBuilder.Entity<Laptop>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("Laptops");
            });
        }
    }
}