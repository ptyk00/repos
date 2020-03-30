using System.Data.Entity;

namespace PIV_TSES
{
    public class TSContext : DbContext
    {
        public DbSet<TSComputer> Computers { get; set; }
        public DbSet<Server> Servers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TSComputer>()
                .HasRequired(x => x.Server)
                .WithRequiredDependent(x => x.Computer);
        }
    }
}