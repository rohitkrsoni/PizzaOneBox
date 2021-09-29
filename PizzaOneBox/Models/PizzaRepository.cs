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
        private readonly List<PizzaBase> _baseList;
        
        private static readonly Dictionary<PizzaSize, decimal> s_pizzaSizePrice = new Dictionary<PizzaSize, decimal> { { PizzaSize.Small, 0m }, { PizzaSize.Medium, 4m }, { PizzaSize.Large, 8m } };
  

        public PizzaRepository()
        {
            _toppingsList = new List<Topping>
            {
                new Topping(){ Id = 1,Name = "Crisp Capsicum",Price = 0.8m},
                new Topping(){ Id = 2,Name = "Fresh Tomato",Price = 0.8m},
                new Topping(){ Id = 3,Name = "Golden Corn",Price = 1.2m},
                new Topping(){ Id = 4, Name = "Grilled Mushroom", Price = 1.8m },
                new Topping(){ Id = 5, Name = "Jalapeno", Price = 1.4m },
                new Topping(){ Id = 6, Name = "Onion", Price = 0.8m },
                new Topping(){ Id = 7, Name = "Paneer", Price = 1.2m },
                new Topping(){ Id = 8, Name = "Red Pepper", Price = 1.2m }

            };
            _baseList = new List<PizzaBase>
            {
                new PizzaBase(){BaseId = 1,BaseName = "Hand Tossed",BasePrice=0m},
                new PizzaBase(){BaseId = 2,BaseName = "Cheese Burst",BasePrice=5.5m},
                new PizzaBase(){BaseId = 3,BaseName = "Wheat Thin Crust",BasePrice=-1.5m},
                new PizzaBase(){BaseId = 4,BaseName = "Fresh Pan Pizza",BasePrice=0.5m},
                new PizzaBase(){BaseId = 5,BaseName = "Italian",BasePrice=0.5m}

            };
            _addOns = new List<AddOn>()
            {
               new AddOn(){Id = 1,AddOnName = "Extra Cheese",AddOnPrice=2m},
               new AddOn(){Id = 2,AddOnName = "Stuff Crust",AddOnPrice=1.8m}
            };

            _menuItems = new List<Pizza>()
            {
                new Pizza(){PizzaId=1,PizzaName="Margherita Pizza",Size = PizzaSize.Small,DefaultCost=14.49m,Toppings=_toppingsList,AddOns = _addOns,CurrentBase=1,PizzaBase = _baseList, Description = "A hugely popular margherita, with a deliciously tangy single cheese topping",PhotoPath = "~/Pizza_images/Margherita.jpg"},
                new Pizza(){PizzaId=2,PizzaName="Farmhouse Pizza",Size=PizzaSize.Small,DefaultCost=15.49m,Toppings=_toppingsList,AddOns = _addOns,PizzaBase = _baseList,CurrentBase=1,Description = "Onion, Capsicum, Tomato, Grilled mushroom",PhotoPath = "~/Pizza_images/Farmhouse.jpg"},
                new Pizza(){PizzaId=3,PizzaName="Peppy Paneer Pizza",Size=PizzaSize.Small,DefaultCost=15.49m,Toppings=_toppingsList,AddOns = _addOns,PizzaBase = _baseList,CurrentBase=1,Description="Paneer, Crisp Capsicum, Red Paprika",PhotoPath = "~/Pizza_images/Peppy_Paneer.jpg"},
                new Pizza(){PizzaId=4,PizzaName="Cheese Corn Pizza",Size=PizzaSize.Small,DefaultCost=15.49m,Toppings=_toppingsList,AddOns = _addOns,PizzaBase = _baseList,CurrentBase=1,Description  = "Golden Corn",PhotoPath = "~/Pizza_images/Corn_&_Cheese.jpg"},
                new Pizza(){PizzaId=5,PizzaName="Veggie Paradise Pizza",Size=PizzaSize.Small,DefaultCost=16.49m,Toppings=_toppingsList,AddOns = _addOns,PizzaBase = _baseList,CurrentBase=1,Description="Golden Corn, Black Olives, capsicum, Red Paprika",PhotoPath = "~/Pizza_images/VeggiParadise.jpg"},
                new Pizza(){PizzaId=6,PizzaName="Extravaganza",Size=PizzaSize.Small,DefaultCost=16.49m,Toppings=_toppingsList,AddOns = _addOns,PizzaBase = _baseList,CurrentBase=1,Description="Mushroom, Corn, Tomato, Jalapeno",PhotoPath = "~/Pizza_images/Veg_Extravaganz.jpg"},
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
                if (addOn.Selected) addOnsCost += addOn.AddOnPrice;
            }
            return  pizza.DefaultCost +
                    _baseList.FirstOrDefault(x => x.BaseId == pizza.CurrentBase).BasePrice+
                    s_pizzaSizePrice.GetValueOrDefault(pizza.Size)+
                    toppingCost+
                    addOnsCost;
        }

        

       
    }
}
