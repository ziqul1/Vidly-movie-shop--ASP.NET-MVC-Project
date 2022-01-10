using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyBest.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }

        public decimal Total { get; set; }
        public System.DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Customer Customer { get; set; }
    }
}