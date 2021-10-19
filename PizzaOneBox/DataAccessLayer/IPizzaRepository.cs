using PizzaOneBox.Models;
using System.Collections.Generic;

namespace PizzaOneBox.DataAccessLayer
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizza> GetAllPizza();
        IList<AddOn> GetAllPizzaAddOn();
        IList<PizzaBase> GetAllPizzaBase();
        IList<PizzaSize> GetAllPizzaSize();
        IList<Topping> GetAllPizzaToppings();
        AddOn GetPizzaAddOnById(int id);
        PizzaBase GetPizzaBaseById(int id);
        Pizza GetPizzaById(int id);
        decimal GetPizzaCost(Pizza pizza);
        PizzaSize GetPizzaSizeById(int id);
        Topping GetPizzaToppingsById(int id);
    }
}
