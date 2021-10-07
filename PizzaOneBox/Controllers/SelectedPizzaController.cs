using Microsoft.AspNetCore.Mvc;
using PizzaOneBox.DataAccessLayer;
using PizzaOneBox.Models;

namespace PizzaOneBox.Controllers
{
    public class SelectedPizzaController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;
        public SelectedPizzaController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }
        [HttpGet]
        public IActionResult SelectedPizza(int id)
        {
            Pizza currentPizza = _pizzaRepository.GetPizza(id);
            ViewBag.ActivateOrderButton = false;
            return View(currentPizza);
        }
        [HttpPost]
        public IActionResult SelectedPizza(Pizza pizza)
        {
            if (!ModelState.IsValid) return View(pizza);
            ViewBag.ActivateOrderButton = true;

            pizza.TotalCost = _pizzaRepository.GetPizzaCost(pizza);
            return View(pizza);
        }
        
    }
}
