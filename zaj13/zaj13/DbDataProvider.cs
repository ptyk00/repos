using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaj13
{
    public class DBDataProvider : IDataProvider
    {
        private readonly Context _context;

        public DBDataProvider(Context context)
        {
            Context = context;
        }

        public Context Context { get; private set; }

        public int GetData()
        {

            return Context.Models.FirstOrDefault().Amount;
        }
    }
}
