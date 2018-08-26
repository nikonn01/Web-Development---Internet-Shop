using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryPicture { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
