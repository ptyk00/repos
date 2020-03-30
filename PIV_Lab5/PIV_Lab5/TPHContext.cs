using System.Data.Entity;

namespace PIV_Lab5
{
    public class TPHContext : DbContext
    {
        public DbSet<Computer> Computers { get; set; }
    }
}