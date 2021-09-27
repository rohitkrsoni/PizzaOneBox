using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        public string PizzaName { get; set; }
        public string ImagePath { get; set; }
        public float PizzaPrice { get; set; }

        public string PizzaToppings { get; set; }
    }
}
