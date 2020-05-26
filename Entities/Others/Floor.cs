using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Others
{
    public class Floor
    {
        public int Number { get; set; }
        public List<Flat> Flats { get; set; }
    }
}
