using System.ComponentModel.DataAnnotations.Schema;

namespace PIV_TSES
{
    [Table("Comp")]
    public class Server
    {
        public int ServerId { get; set; }
        public int ComputerId { get; set; }
        public int BandWidth { get; set; }
        public virtual TSComputer Computer { get; set; }
    }
}