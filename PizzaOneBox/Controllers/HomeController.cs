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
        private readonly IPizzaRepository _pizzaRepository ;

        public HomeController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }
        public ActionResult HomePage()
        {
            var data = _pizzaRepository.GetAllPizzas();

            return View(data);
        }
               
        public ViewResult GetPizza(int id)
        {
            var pizzaDetails = _pizzaRepository.GetPizza(id);
            return View(pizzaDetails);
        }
        
    }
}
