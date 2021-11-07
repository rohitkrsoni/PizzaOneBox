using PizzaOneBox.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzaOneBox.DataAccessLayer
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly List<Pizza> _menuItems;
        private readonly List<Topping> _toppingsList;
        private readonly List<AddOn> _addOns;
        private readonly List<PizzaBase> _baseList;
        
        private static readonly Dictionary<Size, decimal> s_pizzaSizePrice = new Dictionary<Size, decimal> { { Size.Small, 0m }, { Size.Medium, 4m }, { Size.Large, 8m } };
  

        public PizzaRepository()
        {
            /*_toppingsList = new List<Topping>
            {
                new Topping(){ Id = 1,Name = "Crisp Capsicum",Price = 0.8m},
                new Topping(){ Id = 2,Name = "Fresh Tomato",Price = 0.8m},
                new Topping(){ Id = 3,Name = "Golden Corn",Price = 1.2m},
                new Topping(){ Id = 4, Name = "Grilled Mushroom", Price = 1.8m },
                new Topping(){ Id = 5, Name = "Jalapeno", Price = 1.4m },
                new Topping(){ Id = 6, Name = "Onion", Price = 0.8m },
                new Topping(){ Id = 7, Name = "Paneer", Price = 1.2m },
                new Topping(){ Id = 8, Name = "Red Pepper", Price = 1.2m }

            };*/
            _baseList = new List<PizzaBase>
            {
                new PizzaBase(){BaseId = 1,BaseName =BaseName.HandTossed,BaseCost=0m},
                new PizzaBase(){BaseId = 2,BaseName = BaseName.CheeseBurst,BaseCost=5.5m},
                new PizzaBase(){BaseId = 3,BaseName = BaseName.WheatThinCrust,BaseCost=-1.5m},
                new PizzaBase(){BaseId = 4,BaseName = BaseName.FreshPanPizza,BaseCost=0.5m},
                new PizzaBase(){BaseId = 5,BaseName = BaseName.Italian,BaseCost=0.5m}

            };
            /*_addOns = new List<AddOn>()
            {
               new AddOn(){Id = 1,AddOnName = "Extra Cheese",AddOnPrice=2m},
               new AddOn(){Id = 2,AddOnName = "Stuff Crust",AddOnPrice=1.8m}
            };*/

            _menuItems = new List<Pizza>()
            {
                new Pizza(){PizzaId=1,PizzaName="Margherita Pizza",PizzaSizeId = (int)Size.Small,PizzaCost=14.49m,PizzaBaseId=1, Description = "A hugely popular margherita, with a deliciously tangy single cheese topping",PhotoPath = "~/Pizza_images/Margherita.jpg"},
                new Pizza(){PizzaId=2,PizzaName="Farmhouse Pizza",PizzaSizeId=(int)Size.Small,PizzaCost=15.49m,PizzaBaseId=1,Description = "Onion, Capsicum, Tomato, Grilled mushroom",PhotoPath = "~/Pizza_images/Farmhouse.jpg"},
                new Pizza(){PizzaId=3,PizzaName="Peppy Paneer Pizza",PizzaSizeId=(int)Size.Small,PizzaCost=15.49m,PizzaBaseId=1,Description="Paneer, Crisp Capsicum, Red Paprika",PhotoPath = "~/Pizza_images/Peppy_Paneer.jpg"},
                new Pizza(){PizzaId=4,PizzaName="Cheese Corn Pizza",PizzaSizeId=(int)Size.Small,PizzaCost=15.49m,PizzaBaseId=1,Description  = "Golden Corn",PhotoPath = "~/Pizza_images/Corn_&_Cheese.jpg"},
                new Pizza(){PizzaId=5,PizzaName="Veggie Paradise Pizza",PizzaSizeId=(int)Size.Small,PizzaCost=16.49m,PizzaBaseId=1,Description="Golden Corn, Black Olives, capsicum, Red Paprika",PhotoPath = "~/Pizza_images/VeggiParadise.jpg"},
                new Pizza(){PizzaId=6,PizzaName="Extravaganza",PizzaSizeId=(int)Size.Small,PizzaCost=16.49m,PizzaBaseId=1,Description="Mushroom, Corn, Tomato, Jalapeno",PhotoPath = "~/Pizza_images/Veg_Extravaganz.jpg"},
            };

            
        }
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
        public IList<PizzaBase> GetPizzaBases()
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
        public IList<Topping> GetAvailableToppings()
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
                new Pizza(){PizzaId=1,PizzaName="Margherita Pizza",PizzaSizeId = (int)Size.Small,PizzaCost=14.49m,PizzaBaseId=1, Description = "A hugely popular margherita, with a deliciously tangy single cheese topping",PhotoPath = "~/Pizza_images/Margherita.jpg"},
                new Pizza(){PizzaId=2,PizzaName="Farmhouse Pizza",PizzaSizeId=(int)Size.Small,PizzaCost=15.49m,PizzaBaseId=1,Description = "Onion, Capsicum, Tomato, Grilled mushroom",PhotoPath = "~/Pizza_images/Farmhouse.jpg"},
                new Pizza(){PizzaId=3,PizzaName="Peppy Paneer Pizza",PizzaSizeId=(int)Size.Small,PizzaCost=15.49m,PizzaBaseId=1,Description="Paneer, Crisp Capsicum, Red Paprika",PhotoPath = "~/Pizza_images/Peppy_Paneer.jpg"},
                new Pizza(){PizzaId=4,PizzaName="Cheese Corn Pizza",PizzaSizeId=(int)Size.Small,PizzaCost=15.49m,PizzaBaseId=1,Description  = "Golden Corn",PhotoPath = "~/Pizza_images/Corn_&_Cheese.jpg"},
                new Pizza(){PizzaId=5,PizzaName="Veggie Paradise Pizza",PizzaSizeId=(int)Size.Small,PizzaCost=16.49m,PizzaBaseId=1,Description="Golden Corn, Black Olives, capsicum, Red Paprika",PhotoPath = "~/Pizza_images/VeggiParadise.jpg"},
                new Pizza(){PizzaId=6,PizzaName="Extravaganza",PizzaSizeId=(int)Size.Small,PizzaCost=16.49m,PizzaBaseId=1,Description="Mushroom, Corn, Tomato, Jalapeno",PhotoPath = "~/Pizza_images/Veg_Extravaganz.jpg"},
            };
            return pizzas;
        }
        public Pizza GetPizzaById(int id)
        {
            return _menuItems.FirstOrDefault(pizza => pizza.PizzaId == id);
        }

        public decimal GetPizzaCost(Pizza pizza)
        {
            decimal toppingCost = 0m;
            decimal addOnsCost = 0m;

            return pizza.PizzaCost +
                    GetBaseById(pizza.PizzaBaseId).BaseCost+
                    GetSizeById(pizza.PizzaSizeId).SizeCost+
                    toppingCost+
                    addOnsCost;
        }

        public IList<AddOn> GetAvailableAddOns()
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
