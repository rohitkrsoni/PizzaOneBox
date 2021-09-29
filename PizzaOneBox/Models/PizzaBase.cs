using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.Models
{
    public class PizzaBase
    {
        public int BaseId { get; set; }
        public string BaseName { get; set; }
        public decimal BasePrice { get; set; }
    }
}
