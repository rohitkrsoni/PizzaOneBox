using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.Models
{
    public interface IPizzaRepository
    {
        PizzaModel GetPizza(int id);
        float GetPizzaCost(PizzaModel pizza);

       
    }
}
