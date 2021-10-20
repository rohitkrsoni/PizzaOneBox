using Microsoft.AspNetCore.Mvc.Rendering;
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
        public PizzaBase PizzaBase { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public List<SelectListItem> Toppings { get; set; }
        public IList<AddOn> AddOns { get; set; }

    }
}
