using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.Models
{
    public class MockPizzaRepository : IPizzaRepository
    {
        private List<PizzaModel> MenuItems;

        private Dictionary<PizzaBase, float> BasePrice = new Dictionary<PizzaBase, float> { { PizzaBase.HandTossed, 10.49f }, { PizzaBase.CheeseBurst, 15.99f }, { PizzaBase.WheatThinCrust, 8.99f }, { PizzaBase.FreshPanPizza, 10.99f }, { PizzaBase.Italian, 8.99f } };
        private Dictionary<int, float> PizzaCookingCost = new Dictionary<int, float> { { 1, 3.50f }, { 2, 4.50f }, { 3, 4.50f }, { 4, 3.50f }, { 5, 5.50f }, { 6, 5.50f } };
        private Dictionary<PizzaSize, float> PizzaSizeCost = new Dictionary<PizzaSize, float> { { PizzaSize.Small, 0f }, { PizzaSize.Medium, 4f }, { PizzaSize.Large, 8f } };
        private Dictionary<int, float> InitialPizzaPrice = new Dictionary<int, float> { { 1, 14.49f }, { 2, 15.49f }, { 3, 15.49f }, { 4, 14.49f }, { 5, 16.49f }, { 6, 16.49f } };
        private Dictionary<Topping, float> ToppingsPrice = new Dictionary<Topping, float> { {Topping.CrispCapsicum,0.8f }, { Topping.Onion, 0.8f }, { Topping.FreshTomato, 0.8f }, { Topping.Paneer, 1.2f }, { Topping.Jalapeno, 1.4f }, { Topping.GoldenCorn,1.2f }, { Topping.GrilledMushroom, 1.8f } };
        

        public MockPizzaRepository()
        {

            MenuItems = new List<PizzaModel>()
            {
                new PizzaModel(1,"Margherita Pizza",PizzaSize.Small,InitialPizzaPrice.GetValueOrDefault(1)),
                new PizzaModel(2,"Farmhouse Pizza",PizzaSize.Small,InitialPizzaPrice.GetValueOrDefault(2)),
                new PizzaModel(3,"Peppy Paneer",PizzaSize.Small,InitialPizzaPrice.GetValueOrDefault(3))
            };
        }
        public PizzaModel GetPizza(int id)
        {
            return MenuItems.FirstOrDefault(pizza => pizza.PizzaId == id);
        }

        public float GetPizzaCost(PizzaModel pizza)
        {
            
            return  BasePrice.GetValueOrDefault(pizza.Base) +
                    PizzaCookingCost.GetValueOrDefault(pizza.PizzaId) + 
                    PizzaSizeCost.GetValueOrDefault(pizza.Size)+GetToppingsCost(pizza.Toppings);
        }

        public float GetToppingsCost(IEnumerable<Topping> toppings)
        {
            var toppingCost = 0f;
            foreach(var Topping in toppings)
            {
                toppingCost = toppingCost + ToppingsPrice.GetValueOrDefault(Topping);
            }
            return toppingCost;
        }

       
    }
}
