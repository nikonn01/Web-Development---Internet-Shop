using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    public class ColourAllocation
    {
        public int ColourAllocationID { get; set; }
        public int ProductID { get; set; }
        public int ColourID { get; set; }
        

        public Product Products { get; set; }
        public Colour Colours { get; set; }
    }
}
