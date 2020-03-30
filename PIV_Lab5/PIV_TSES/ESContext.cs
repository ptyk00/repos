using System.Data.Entity;

namespace PIV_TSES
{
    public class ESContext : DbContext
    {
        public DbSet<Computer> Computers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Computer>()
                .Map(map =>
                {
                    map.Properties(p => new
                    {
                        p.CoolingType,
                        p.Description
                    });
                    map.ToTable("PolaTekstowe");
                })
                .Map(map =>
                {
                    map.Properties(p => new
                    {
                        p.Weight,
                        p.Price
                    });
                    map.ToTable("PolaLiczbowe");
                });
        }
    }
}