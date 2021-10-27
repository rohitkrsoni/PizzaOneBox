using PizzaOneBox.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PizzaOneBox.DataAccessLayer
{
    public class PizzaRepository : IPizzaRepository
    {   
             
        public Pizza GetPizza(int id)
        {
            return GetMenuItems().FirstOrDefault(pizza=>pizza.Id==id);
        }

        public decimal GetPizzaCost(OrderedPizzaDetails orderedPizzaDetails)
        {
            decimal toppingCost = 0m;
            decimal addOnsCost = 0m;
            decimal baseCost = 0m;
           foreach(var topping in orderedPizzaDetails.Toppings)
            {
                if (topping.Selected) toppingCost += topping.Price;
            }
            foreach (var addOn in orderedPizzaDetails.AddOns)
            {
                if (addOn.Selected) addOnsCost += addOn.AddOnPrice;
            }
            baseCost = GetPizzaBaseList().FirstOrDefault(b => b.BaseId == orderedPizzaDetails.BaseId).BasePrice;
            return orderedPizzaDetails.SelectedPizza.DefaultCost +
                    GetSizeList().FirstOrDefault(pizzaSize=>pizzaSize.size== orderedPizzaDetails.Size).sizeCost+
                    baseCost+
                    toppingCost+
                    addOnsCost;
        }

        public IList<Pizza> GetMenuItems()
        {
            var menuItems = new List<Pizza>()
            {
                new Pizza(){Id=1, PhotoPath="/Pizza_images/margherita.jpg",PizzaDescription="A hugely popular margherita, with a single cheese topping",PizzaName="Margherita",DefaultCost=14.49m},
                new Pizza(){Id=2, PhotoPath="/Pizza_images/Farmhouse.jpg",PizzaDescription="Onion, Capsicum, Tomato, Grilled Mushroom",PizzaName="Farm House",DefaultCost=15.49m},
                new Pizza(){Id=3, PhotoPath="/Pizza_images/Peppy_Paneer.jpg",PizzaDescription="Paneer, Crisp Capsicum, Red Paprika",PizzaName="Peppy Paneer",DefaultCost=15.49m},
                new Pizza(){Id=4, PhotoPath="/Pizza_images/Corn_&_Cheese.jpg",PizzaDescription="Golden Corn",PizzaName="Cheese Corn",DefaultCost=14.49m},
                new Pizza(){Id=5, PhotoPath="/Pizza_images/VeggiParadise.jpg",PizzaDescription="Golden Corn, Black Olives, Capsicum, Red Paprika",PizzaName="Veggi Paradise",DefaultCost=14.49m},
                new Pizza(){Id=6, PhotoPath="/Pizza_images/Veg_Extravaganz.jpg",PizzaDescription="Mushroom, Corn, Tomato, Jalapeno",PizzaName="Veg Extravaganz",DefaultCost=16.49m},

            };
            return menuItems;
        }

        public IList<PizzaSize> GetSizeList()
        {
            var sizeCostList = new List<PizzaSize>()
            {
                new PizzaSize(){size=Size.Small,sizeCost=0m},
                new PizzaSize(){size=Size.Medium,sizeCost=4m},
                new PizzaSize(){size=Size.Large,sizeCost=8m},
            };
            return sizeCostList;
        }

        public IList<AddOn> GetAddOnsList()
        {
            var addOnsList = new List<AddOn>()
            {
               new AddOn(){Id = 1,AddOnName = "Extra Cheese",AddOnPrice=2m},
               new AddOn(){Id = 2,AddOnName = "Stuff Crust",AddOnPrice=1.8m}
            };
            return addOnsList;
        }
        public IList<PizzaBase> GetPizzaBaseList()
        {
            var baseList = new List<PizzaBase>
            {
                new PizzaBase(){BaseId = 1,BaseName = "Hand Tossed",BasePrice=0m},
                new PizzaBase(){BaseId = 2,BaseName = "Cheese Burst",BasePrice=5.5m},
                new PizzaBase(){BaseId = 3,BaseName = "Wheat Thin Crust",BasePrice=-1.5m},
                new PizzaBase(){BaseId = 4,BaseName = "Fresh Pan Pizza",BasePrice=0.5m},
                new PizzaBase(){BaseId = 5,BaseName = "Italian",BasePrice=0.5m}

            };
            return baseList;
        }

        public IList<Topping> GetToppingsList()
        {
            var toppingsList = new List<Topping>
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
            return toppingsList;
        }
    }
}
