using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    public class Material
    {
        public int MaterialID { get; set; }
        public string MaterialDescription { get; set; }
       
        public ICollection<Product> Products { get; set; }
    }
}
