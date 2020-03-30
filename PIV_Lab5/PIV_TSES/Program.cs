namespace PIV_TSES
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var esCtx = new ESContext();
            esCtx.Computers.Add(new Computer() {Description = "test", CoolingType = "none", Price = 333, Weight = 2});
            esCtx.SaveChanges();

            var tsCtx = new TSContext();
            tsCtx.Computers.Add(new TSComputer()
            {
                Description = "test", CoolingType = "none", Price = 333, Weight = 2, 
                Server = new Server() { BandWidth = 100 }
            });
            tsCtx.SaveChanges();
        }
    }
}