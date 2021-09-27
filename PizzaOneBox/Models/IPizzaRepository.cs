using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.Models
{
    public interface IPizzaRepository
    {
        Pizza GetPizza(int id);
        decimal GetPizzaCost(Pizza pizza);

       
    }
}
