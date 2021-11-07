using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaOneBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.ViewModels
{
    public class SelectedPizzaViewModel
    {
        public Pizza Pizza { get; set; }
        public List<SelectListItem> Toppings { get; set; }
        public List<SelectListItem> AddOns { get; set; }

    }
}
