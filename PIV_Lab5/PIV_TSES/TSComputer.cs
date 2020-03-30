using System.ComponentModel.DataAnnotations.Schema;

namespace PIV_TSES
{
    [Table("Comp")]
    public class TSComputer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CoolingType { get; set; }
        public int Weight { get; set; }
        public virtual Server Server { get; set; }
    }
}