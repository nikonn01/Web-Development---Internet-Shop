using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    public class AllocateProductOrder
    {
        public int AllocateProductOrderID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int Value { get; set; }


        public Product Products { get; set; }
        public Order Orders { get; set; }
    }
}
