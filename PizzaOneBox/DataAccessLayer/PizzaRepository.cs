using PizzaOneBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaOneBox.DataAccessLayer
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly List<Pizza> _pizza;
        private readonly List<Topping> _toppingsList;
        private readonly List<AddOn> _addOns;
        private readonly List<PizzaBase> _baseList;
        private readonly List<PizzaSize> _sizeList;

        // private static readonly Dictionary<PizzaSize, decimal> s_pizzaSizePrice = new Dictionary<PizzaSize, decimal> { { PizzaSize.Small, 0m }, { PizzaSize.Medium, 4m }, { PizzaSize.Large, 8m } };


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

            _sizeList = new List<PizzaSize>()
            {
                new PizzaSize(){Id = 1, Price = 1, Size = Size.Small },
                new PizzaSize(){Id = 2, Price = 4, Size = Size.Medium },
                new PizzaSize(){Id = 3, Price = 8, Size = Size.Large }
            };

            _pizza = new List<Pizza>()
            {
                new Pizza(){PizzaId=1,PizzaName="Margherita Pizza", Description = "A hugely popular margherita, with a deliciously tangy single cheese topping",PhotoPath = "~/Pizza_images/Margherita.jpg",Price = 14.49m},
                new Pizza(){PizzaId=2,PizzaName="Farmhouse Pizza",Description = "Onion, Capsicum, Tomato, Grilled mushroom",PhotoPath = "~/Pizza_images/Farmhouse.jpg", Price = 15.49m},
                new Pizza(){PizzaId=3,PizzaName="Peppy Paneer Pizza",Description="Paneer, Crisp Capsicum, Red Paprika",PhotoPath = "~/Pizza_images/Peppy_Paneer.jpg", Price = 15.49m},
                new Pizza(){PizzaId=4,PizzaName="Cheese Corn Pizza",Description  = "Golden Corn",PhotoPath = "~/Pizza_images/Corn_&_Cheese.jpg", Price = 14.49m},
                new Pizza(){PizzaId=5,PizzaName="Veggie Paradise Pizza",Description="Golden Corn, Black Olives, capsicum, Red Paprika",PhotoPath = "~/Pizza_images/VeggiParadise.jpg", Price = 14.49m},
                new Pizza(){PizzaId=6,PizzaName="Extravaganza",Description="Mushroom, Corn, Tomato, Jalapeno",PhotoPath = "~/Pizza_images/Veg_Extravaganz.jpg", Price = 16.49m},
                new Pizza(){PizzaId=7,PizzaName="Custom",Description="Make your own Pizza add what ever toppings you like.",PhotoPath = "~/Pizza_images/Veg_Extravaganz.jpg", Price = 10}
            };

            
        }

        public IEnumerable<Pizza> GetAllPizza()
        {
            return _pizza;
        }
        public Pizza GetPizzaById(int id)
        {
            return _pizza.FirstOrDefault(pizza => pizza.PizzaId == id);
        }

        public IList<Topping> GetAllPizzaToppings()
        {
            return _toppingsList;
        }

        public Topping GetPizzaToppingsById(int id)
        {
            return _toppingsList.FirstOrDefault(t => t.Id == id);
        }

        public IList<PizzaBase> GetAllPizzaBase()
        {
            return _baseList;
        }

        public PizzaBase GetPizzaBaseById(int id)
        {
            return _baseList.FirstOrDefault(b => b.BaseId == id);
        }

        public IList<PizzaSize> GetAllPizzaSize()
        {
            return _sizeList;
        }

        public PizzaSize GetPizzaSizeById(int id)
        {
            return _sizeList.FirstOrDefault(s => s.Id == id);
        }

        public IList<AddOn> GetAllPizzaAddOn()
        {
            return _addOns;
        }

        public AddOn GetPizzaAddOnById(int id)
        {
            return _addOns.FirstOrDefault(a => a.Id == id);
        }

        public decimal GetPizzaCost(Pizza pizza)
        {
            return CalculateTotalPizzaCost(pizza);
        }

        private decimal CalculateToppingsCost(Pizza pizza)
        {
            decimal toppingCost = 0m;

            foreach (var toppingId in pizza.ToppingsId)
            {
                int id;
                bool number = int.TryParse(toppingId, out id);

                if (number)
                {
                    var topping = GetPizzaToppingsById(id);
                    toppingCost += topping.Price;
                }

            }

            return toppingCost;
        }

        private decimal CalculateAddOnsCost(Pizza pizza)
        {
            decimal addOnsCost = 0m;


            foreach (var addOnId in pizza.AddOnsId)
            {
                int id;
                bool number = int.TryParse(addOnId, out id);

                if (number)
                {
                    var addOn = GetPizzaAddOnById(id);
                    addOnsCost += addOn.AddOnPrice;
                }

            }

            return addOnsCost;
        }

        private decimal CalculateTotalPizzaCost(Pizza pizza)
        {
            var toppingCost = CalculateToppingsCost(pizza);
            var addOnsCost = CalculateAddOnsCost(pizza);

            var totalPizzaCost = _baseList.FirstOrDefault(b => b.BaseId == pizza.PizzaBaseId).BasePrice +
                                _sizeList.FirstOrDefault(s => s.Id == pizza.PizzaSizeId).Price +
                                toppingCost + addOnsCost;

            return totalPizzaCost;
        }
        

       
    }
}
