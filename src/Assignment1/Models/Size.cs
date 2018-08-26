using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    public class Size
    {
        public int SizeID { get; set; }
        public string SizeDescription { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
