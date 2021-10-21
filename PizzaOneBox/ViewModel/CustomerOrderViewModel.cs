using PizzaOneBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.ViewModel
{
    public class CustomerOrderViewModel
    {
        public OrderDetail OrderDetail { get; set; }
        public CustomerDetailsModel CustomerDetails { get; set; }
    }
}
