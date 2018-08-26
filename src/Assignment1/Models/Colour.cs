using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    public class Colour
    {
        public int ColourID { get; set; }
        public string ColourName { get; set; }
        public string ColourPicture { get; set; }

        public ICollection<ColourAllocation> ColourAllocations { get; set; }
    }
}
