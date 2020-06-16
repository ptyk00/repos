using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie_Lab4
{
    public class SeasonDto
    {
        public string School { get; set; }
        public string Year { get; set; }
        public int Games { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
        public int PreseasonRank { get; set; }
        public int PostseasonRank { get; set; }
    }
}
