using Microsoft.AspNetCore.Mvc;
using PizzaOneBox.DataAccessLayer;
using PizzaOneBox.Models;
using System.Collections.Generic;
namespace PizzaOneBox.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;
        public HomeController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }
   
        [HttpGet]
        public ActionResult HomePage()
        {
            var pizzaList = _pizzaRepository.GetPizzas();
            return View(pizzaList);
        }
                 
       

    }
}
