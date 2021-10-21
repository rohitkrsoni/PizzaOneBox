using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Customer { get; set; }
        public CustomerDetailsModel CustomerDetails { get; set; }
        public int OrderNumber { get; internal set; }
        public DateTime Date { get; set; }
    }
}
