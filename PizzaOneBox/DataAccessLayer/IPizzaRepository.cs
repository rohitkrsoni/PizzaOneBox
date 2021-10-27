using PizzaOneBox.Models;
using System.Collections.Generic;

namespace PizzaOneBox.DataAccessLayer
{
    public interface IPizzaRepository
    {
        Pizza GetPizza(int id);
        decimal GetPizzaCost(OrderedPizzaDetails model);
        IList<Pizza> GetMenuItems();
        IList<PizzaSize> GetSizeList();
        IList<AddOn> GetAddOnsList();
        IList<Topping> GetToppingsList();
        IList<PizzaBase> GetPizzaBaseList();

       
    }
}
