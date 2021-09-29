using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.Models
{
    public class Pizza
    { 
        
        public int PizzaId { get; set; }
        public String PizzaName { get; set; }
        public PizzaSize Size { get; set; }
        public decimal DefaultCost { get; set; }
        public decimal TotalCost { get; set; }
        public int CurrentBase { get; set; }
        public IList<PizzaBase> PizzaBase { get; set; }
        [ToppingsValidator(ErrorMessage = "Please select at least 1 Topping(s)")]
        public IList<Topping> Toppings { get; set; }
        public IList<AddOn> AddOns { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }

        
    }
}

