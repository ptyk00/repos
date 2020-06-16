using System;
using System.Collections.Generic;
using System.Text;


namespace Zadanie_Lab4
{
    public class Coache
    {
        public Coache()
        {
            Seasons = new List<Season>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Team Teams { get; set; }
        public virtual ICollection<Season> Seasons { get; set; }
    }
}
