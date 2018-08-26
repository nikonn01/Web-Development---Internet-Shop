using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        
        public int BrandID { get; set; }
        public int MaterialID { get; set; }
        public int SizeID { get; set; }
        public string ProductDescription { get; set; }
        public int Price { get; set; }
        public int TotalValue { get; set; }
        public string SmallImage { get; set; }
        public string MediumImage { get; set; }
        public string LargeImage { get; set; }

        public ICollection<ColourAllocation> ColourAllocations { get; set; }
        public ICollection<AllocateProductOrder> AllocateProductOrders { get; set; }

       
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public Material Material { get; set; }
        public Size Size { get; set; }
    }
}
