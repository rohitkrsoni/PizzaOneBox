using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.Models
{
    public class Order
    {
        public Pizza Pizza { get; set; }
        public CustomerDetailsModel CustomerDetails { get; set; }
        public int OrderId { get; set; }
    }
}
