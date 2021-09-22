using Microsoft.AspNetCore.Mvc;
using PizzaOneBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.Controllers
{
    public class SelectedPizzaController : Controller
    {
        public IPizzaRepository PizzaRepository;
        public SelectedPizzaController(IPizzaRepository pizzaRepository)
        {
            this.PizzaRepository = pizzaRepository;
        }
        [HttpGet]
        public IActionResult SelectedPizza(int id)
        {
            PizzaModel CurrentPizza = PizzaRepository.GetPizza(id);
            return View(CurrentPizza);
        }
        [HttpPost]
        public IActionResult SelectedPizza(PizzaModel pizza)
        {
            if (ModelState.IsValid == false) return View(pizza);
            pizza.Cost = PizzaRepository.GetPizzaCost(pizza);
            return View(pizza);
        }
    }
}
