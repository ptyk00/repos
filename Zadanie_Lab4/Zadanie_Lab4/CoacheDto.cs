using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie_Lab4
{
     public class CoacheDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<SeasonDto> Seasons { get; set; }
    }
}
