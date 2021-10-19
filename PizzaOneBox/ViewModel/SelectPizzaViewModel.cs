using PizzaOneBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.ViewModel
{
    public class SelectPizzaViewModel
    {
        public Pizza Pizza { get; set; }
        public IList<PizzaBase> PizzaBase { get; set; }
        public IList<PizzaSize> PizzaSize { get; set; }
        public IList<Topping> Toppings { get; set; }
        public IList<AddOn> AddOns { get; set; }

    }
}
