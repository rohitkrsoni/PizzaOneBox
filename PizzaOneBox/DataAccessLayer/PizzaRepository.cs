using PizzaOneBox.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzaOneBox.DataAccessLayer
{
    public class PizzaRepository : IPizzaRepository
    {
        public List<PizzaSize> GetPizzaSizes()
        {
            var sizes = new List<PizzaSize>()
            {
                new PizzaSize(){SizeId =1,Size =Size.Small,SizeCost = 0m},
                new PizzaSize(){SizeId =2,Size =Size.Medium,SizeCost = 4m},
                new PizzaSize(){SizeId =3,Size =Size.Large,SizeCost = 8m}
            };
            return sizes;
        }
        public PizzaSize GetSizeById(int id)
        {
            return GetPizzaSizes().FirstOrDefault(PizzaSize => PizzaSize.SizeId == id);
        }
        public List<PizzaBase> GetPizzaBases()
        {
            var baseList = new List<PizzaBase>
            {
                new PizzaBase(){BaseId = 1,BaseName = BaseName.HandTossed,BaseCost=0m},
                new PizzaBase(){BaseId = 2,BaseName = BaseName.CheeseBurst,BaseCost=5.5m},
                new PizzaBase(){BaseId = 3,BaseName = BaseName.WheatThinCrust,BaseCost=-1.5m},
                new PizzaBase(){BaseId = 4,BaseName = BaseName.FreshPanPizza,BaseCost=0.5m},
                new PizzaBase(){BaseId = 5,BaseName = BaseName.Italian,BaseCost=0.5m}

            };
            return baseList;
        }
        public PizzaBase GetBaseById(int id)
        {
            return GetPizzaBases().FirstOrDefault(PizzaBase => PizzaBase.BaseId == id);
        }
        public List<Topping> GetAvailableToppings()
        {
            var _toppingsList = new List<Topping>
            {
                new Topping(){ Id = 1, Name = "Crisp Capsicum",Price = 0.8m},
                new Topping(){ Id = 2, Name = "Fresh Tomato",Price = 0.8m},
                new Topping(){ Id = 3, Name = "Golden Corn",Price = 1.2m},
                new Topping(){ Id = 4, Name = "Grilled Mushroom", Price = 1.8m },
                new Topping(){ Id = 5, Name = "Jalapeno", Price = 1.4m },
                new Topping(){ Id = 6, Name = "Onion", Price = 0.8m },
                new Topping(){ Id = 7, Name = "Paneer", Price = 1.2m },
                new Topping(){ Id = 8, Name = "Red Pepper", Price = 1.2m }

            };
            return _toppingsList;
        }
        public IList<Pizza> GetPizzas()
        {
            var pizzas = new List<Pizza>()
            {
                new Pizza(){PizzaId=1,PizzaName="Margherita Pizza",PizzaSizeId = 1,PizzaCost=14.49m,PizzaBaseId=1, Description = "A hugely popular margherita, with a single cheese topping",PhotoPath = "~/Pizza_images/Margherita.jpg"},
                new Pizza(){PizzaId=2,PizzaName="Farmhouse Pizza",PizzaSizeId=1,PizzaCost=15.49m,PizzaBaseId=1,Description = "Onion, Capsicum, Tomato, Grilled mushroom",PhotoPath = "~/Pizza_images/Farmhouse.jpg"},
                new Pizza(){PizzaId=3,PizzaName="Peppy Paneer Pizza",PizzaSizeId=1,PizzaCost=15.49m,PizzaBaseId=1,Description="Paneer, Crisp Capsicum, Red Paprika",PhotoPath = "~/Pizza_images/Peppy_Paneer.jpg"},
                new Pizza(){PizzaId=4,PizzaName="Cheese Corn Pizza",PizzaSizeId=1,PizzaCost=15.49m,PizzaBaseId=1,Description  = "Golden Corn",PhotoPath = "~/Pizza_images/Corn_&_Cheese.jpg"},
                new Pizza(){PizzaId=5,PizzaName="Veggie Paradise Pizza",PizzaSizeId=1,PizzaCost=16.49m,PizzaBaseId=1,Description="Golden Corn, Black Olives, capsicum, Red Paprika",PhotoPath = "~/Pizza_images/VeggiParadise.jpg"},
                new Pizza(){PizzaId=6,PizzaName="Extravaganza",PizzaSizeId=1,PizzaCost=16.49m,PizzaBaseId=1,Description="Mushroom, Corn, Tomato, Jalapeno",PhotoPath = "~/Pizza_images/Veg_Extravaganz.jpg"},
            };
            return pizzas;
        }
        public Pizza GetPizzaById(int id)
        {
            return GetPizzas().FirstOrDefault(pizza => pizza.PizzaId == id);
        }

        public decimal GetPizzaCost(Pizza pizza)
        {

            return  GetPizzaById(pizza.PizzaId).PizzaCost +
                    GetBaseById(pizza.PizzaBaseId).BaseCost +
                    GetSizeById(pizza.PizzaSizeId).SizeCost +
                    CalculateToppingsCost(pizza.Toppings) +
                    CalculateAddOnCost(pizza.AddOns);
        }
        public decimal CalculateToppingsCost (List<Topping> toppings)
        {
            decimal toppingCost = 0m;
            foreach(var topping in toppings)
            {
                if (topping.Selected)
                    toppingCost += topping.Price;
            }
            return toppingCost;
        }

        public decimal CalculateAddOnCost(List<AddOn> addons)
        {
            decimal addOnCost = 0m;
            foreach (var addon in addons)
            {
                if (addon.Selected)
                    addOnCost += addon.AddOnPrice;
            }
            return addOnCost;
        }

        public List<AddOn> GetAvailableAddOns()
        {
            var _addOns = new List<AddOn>()
            {
               new AddOn(){Id = 1,AddOnName = "Extra Cheese",AddOnPrice=2m},
               new AddOn(){Id = 2,AddOnName = "Stuff Crust",AddOnPrice=1.8m}
            };
            return _addOns;
        }

       
    }
}