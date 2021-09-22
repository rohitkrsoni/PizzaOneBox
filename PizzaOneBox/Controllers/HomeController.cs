using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaOneBox.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.Controllers
{
    public class HomeController : Controller
    {
        public IPizzaRepository PizzaRepository;
        public HomeController(IPizzaRepository pizzaRepository)
        {
            this.PizzaRepository = pizzaRepository;
        }
        public IActionResult Index()
        {
            return View();
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
