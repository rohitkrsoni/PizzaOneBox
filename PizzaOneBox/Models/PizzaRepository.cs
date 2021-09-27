using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.Models
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly List<Pizza> _menuItems;
        private readonly List<Topping> _toppingsList;
        private readonly List<AddOn> _addOns;

        private static readonly Dictionary<PizzaBase, decimal> s_pizzaBasePrice = new Dictionary<PizzaBase, decimal> { { PizzaBase.HandTossed, 10.49m }, { PizzaBase.CheeseBurst, 15.99m }, { PizzaBase.WheatThinCrust, 8.99m }, { PizzaBase.FreshPanPizza, 10.99m }, { PizzaBase.Italian, 8.99m } };
        private static readonly Dictionary<int, decimal> s_pizzaCookingPrice = new Dictionary<int, decimal> { { 1, 3.50m }, { 2, 4.50m }, { 3, 4.50m }, { 4, 3.50m }, { 5, 5.50m }, { 6, 5.50m } };
        private static readonly Dictionary<PizzaSize, decimal> s_pizzaSizePrice = new Dictionary<PizzaSize, decimal> { { PizzaSize.Small, 0m }, { PizzaSize.Medium, 4m }, { PizzaSize.Large, 8m } };
        
        
        

        public PizzaRepository()
        {
            _toppingsList = new List<Topping>
            {
                new Topping(1,"Crisp Capsicum ",0.8m),
                new Topping(2,"Fresh Tomato",0.8m),
                new Topping(3,"Golden Corn",1.2m),
                new Topping(4,"Grilled Mushroom",1.8m),
                new Topping(5,"Jalapeno",1.4m),
                new Topping(6,"Onion",0.8m),
                new Topping( 7,"Paneer",1.2m),
                new Topping(8,"Red Pepper",1.2m)

            };
            _addOns = new List<AddOn>()
            {
               new AddOn(){Id = 1,AddOnName = "Extra Cheese",AddOnPrice=2m},
               new AddOn(){Id = 2,AddOnName = "Stuff Crust",AddOnPrice=1.8m}
            };

            _menuItems = new List<Pizza>()
            {
                new Pizza(){PizzaId=1,PizzaName="Margherita Pizza",Size = PizzaSize.Small,Cost=14.49m,Toppings=_toppingsList,AddOns = _addOns,Base = PizzaBase.HandTossed, Description = "A hugely popular margherita, with a deliciously tangy single cheese topping",PhotoPath = "~/Pizza_images/Margherita.jpg"},
                new Pizza(){PizzaId=2,PizzaName="Farmhouse Pizza",Size=PizzaSize.Small,Cost=15.49m,Toppings=_toppingsList,AddOns = _addOns,Base = PizzaBase.HandTossed,Description = "Onion, Capsicum, Tomato, Grilled mushroom",PhotoPath = "~/Pizza_images/Farmhouse.jpg"},
                new Pizza(){PizzaId=3,PizzaName="Peppy Paneer Pizza",Size=PizzaSize.Small,Cost=15.49m,Toppings=_toppingsList,AddOns = _addOns,Base = PizzaBase.HandTossed,Description="Paneer, Crisp Capsicum, Red Paprika",PhotoPath = "~/Pizza_images/Peppy_Paneer.jpg"},
                new Pizza(){PizzaId=4,PizzaName="Cheese Corn Pizza",Size=PizzaSize.Small,Cost=15.49m,Toppings=_toppingsList,AddOns = _addOns,Base = PizzaBase.HandTossed,Description  = "Golden Corn",PhotoPath = "~/Pizza_images/Corn_&_Cheese.jpg"},
                new Pizza(){PizzaId=5,PizzaName="Veggie Paradise Pizza",Size=PizzaSize.Small,Cost=16.49m,Toppings=_toppingsList,AddOns = _addOns,Base = PizzaBase.HandTossed,Description="Golden Corn, Black Olives, capsicum, Red Paprika",PhotoPath = "~/Pizza_images/VeggiParadise.jpg"},
                new Pizza(){PizzaId=6,PizzaName="Extravaganza",Size=PizzaSize.Small,Cost=16.49m,Toppings=_toppingsList,AddOns = _addOns,Base = PizzaBase.HandTossed,Description="Mushroom, Corn, Tomato, Jalapeno",PhotoPath = "~/Pizza_images/Veg_Extravaganz.jpg"},
            };

            
        }
        public Pizza GetPizza(int id)
        {
            return _menuItems.FirstOrDefault(pizza => pizza.PizzaId == id);
        }

        public decimal GetPizzaCost(Pizza pizza)
        {
            decimal toppingCost = 0m;
            decimal addOnsCost = 0m;
           foreach(var topping in pizza.Toppings)
            {
                if (topping.CheckBoxAnswer) toppingCost += topping.Price;
            }
            foreach (var addOn in pizza.AddOns)
            {
                if (addOn.selected) addOnsCost += addOn.AddOnPrice;
            }

            return  s_pizzaBasePrice.GetValueOrDefault(pizza.Base) +
                    s_pizzaCookingPrice.GetValueOrDefault(pizza.PizzaId) + 
                    s_pizzaSizePrice.GetValueOrDefault(pizza.Size)+toppingCost+addOnsCost;
        }

        

       
    }
}
