using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace zaj13
{
    public class FileDataProvider : IDataProvider
    {
        public int GetData()
        {
            var content = File.ReadAllText(@"C:\Users\Patryk\Desktop\repos\zaj13\zaj13\Data.txt");
            var lines = content.Split(new[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            return Convert.ToInt32(lines[0]);
        }
    }
}
