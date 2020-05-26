using Entities.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Interfaces
{
    public interface IFunctionalUnity
    {
        public char Name { get; set; }
        public User Renter { get; set; }
        public User Owner { get; set; }
        public decimal Percentage { get; set; }
    }
}
