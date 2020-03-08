using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Order
    {
        public Order()
        {
            Details = new List<OrderDetails>();
        }

        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerID { get; set; }
        public ICollection<OrderDetails> Details { get; set; } 
    }
}
