using PizzaOneBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.ViewModel
{
    public class OrderViewModel
    {
        public string OrderToJson { get; set; }
        public string OrderDetailToJson { get; set; }
        public Order Order { get; internal set; }
        public OrderDetail OrderDetail { get; internal set; }
    }
}
