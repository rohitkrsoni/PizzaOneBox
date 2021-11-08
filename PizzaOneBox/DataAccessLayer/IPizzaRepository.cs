using PizzaOneBox.Models;
using System.Collections.Generic;

namespace PizzaOneBox.DataAccessLayer
{
    public interface IPizzaRepository
    {
        Pizza GetPizzaById(int id);
        decimal GetPizzaCost(Pizza pizza);
        List<PizzaSize> GetPizzaSizes();
        PizzaSize GetSizeById(int id);
        List<PizzaBase> GetPizzaBases();
        List<Topping> GetAvailableToppings();
        List<AddOn> GetAvailableAddOns();
        public PizzaBase GetBaseById(int id);
        public IList<Pizza> GetPizzas();




    }
}