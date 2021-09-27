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
        private readonly PizzaRepository _pizzaRepository = null;

        public HomeController()
        {
            _pizzaRepository = new PizzaRepository();
        }
        public ActionResult HomePage()
        {
            return View();
        }

        public ViewResult GetAllPizzas()
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
