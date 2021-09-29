using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.Models
{
    public class AddOn
    {
        public int Id { get; set; }
        public string AddOnName { get; set; }
        public decimal AddOnPrice { get; set; }
        public bool Selected { get; set; }

    }
}
