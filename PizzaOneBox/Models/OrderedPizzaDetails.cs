using System.Collections.Generic;

namespace PizzaOneBox.Models
{
    public class OrderedPizzaDetails
    {
        public Pizza SelectedPizza { get; set; }
        public Size Size { get; set; }
        public decimal TotalCost { get; set; }
        public int BaseId { get; set; }
        public IList<PizzaBase> Base { get; set; }

        [ToppingsValidator(ErrorMessage = "Please select at least 1 Topping(s)")]
        public IList<Topping> Toppings { get; set; }
        public IList<AddOn> AddOns { get; set; }

        
    }
}

