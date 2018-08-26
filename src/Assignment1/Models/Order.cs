using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int OrderNumber { get; set; }
        public string OrderStatus { get; set; }
        public int NetAmount { get; set; }
        public int GST { get; set; }
        public int GrossAmount { get; set; }
        public DateTime OrderDate { get; set; }

        public User Users { get; set; }

        public ICollection<AllocateProductOrder> AllocateProductOrders { get; set; }

    }
}
