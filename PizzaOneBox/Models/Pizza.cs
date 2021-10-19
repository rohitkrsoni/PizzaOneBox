using System.Collections.Generic;

namespace PizzaOneBox.Models
{
    public class Pizza
    { 
        
        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public int PizzaSizeId { get; set; }
        public int PizzaBaseId { get; set; }
        public IList<string> ToppingsId { get; set; }
        public IList<string> AddOnsId { get; set; }
        public decimal Price { get; set; }
        // public PizzaSize Size { get; set; }
        //public decimal DefaultCost { get; set; }
        // public decimal TotalCost { get; set; }
        //public IList<PizzaBase> PizzaBase { get; set; }//base id

        //[ToppingsValidator(ErrorMessage = "Please select at least 1 Topping(s)")]
        //public List<Topping> Toppings { get; set; }
        //public IList<AddOn> AddOns { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }

        
    }
}

