using Entities.DatabaseModels;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Others
{
    public class Flat : IFunctionalUnity
    {
        public char Name { get; set; }
        public User Renter { get; set; }
        public User Owner { get; set; }
        public decimal Percentage { get; set; }
    }
}
