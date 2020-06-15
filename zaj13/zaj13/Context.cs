using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace zaj13
{
    public class Context : DbContext
    {
        public DbSet<Model> Models { get; set; }
        public Context()
        {

            Models.Add(new Model() { Amount = 5, Text = "test" });

        }
    }
}
