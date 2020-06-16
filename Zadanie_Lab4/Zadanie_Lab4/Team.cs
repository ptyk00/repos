using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie_Lab4
{
    public class Team
    {
        public Team()
        {
            Coaches = new List<Coache>();
        }
        public int Id { get; set; }
        public string School { get; set; }
        public string Mascot { get; set; }
        public string Abbreviation { get; set; }
        public string AltName1 { get; set; }
        public string AltName2 { get; set; }
        public string AltName3 { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        public string Color { get; set; }
        public string AltColor { get; set; }
        public virtual ICollection<Coache> Coaches { get; set; }
    }
}
