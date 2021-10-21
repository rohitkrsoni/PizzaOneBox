using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        public string Pizza { get; set; }
        public Pizza Pizzas { get; set; }
        public decimal TotalCost { get; set; }
    }
}
