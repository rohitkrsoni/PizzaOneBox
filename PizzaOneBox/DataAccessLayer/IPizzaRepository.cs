using PizzaOneBox.Models;

namespace PizzaOneBox.DataAccessLayer
{
    public interface IPizzaRepository
    {
        Pizza GetPizza(int id);
        decimal GetPizzaCost(Pizza pizza);

       
    }
}
