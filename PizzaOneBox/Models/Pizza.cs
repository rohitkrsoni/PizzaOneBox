using System.Collections.Generic;
namespace PizzaOneBox.Models
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public int PizzaSizeId { get; set; }
        public decimal PizzaCost { get; set; }
        public int PizzaBaseId { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public List<Topping> Toppings { get; set; }
        public List<AddOn> AddOns { get; set; }
    }
}
