using System.Collections.Generic;

namespace PizzaOneBox.Models
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizza> GetAllPizzas();
        Pizza GetPizza(int id);
    }
}