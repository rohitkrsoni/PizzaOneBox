using Microsoft.AspNetCore.Mvc;
using PizzaOneBox.DataAccessLayer;
using PizzaOneBox.Models;
using PizzaOneBox.ViewModel;

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
            SelectPizzaViewModel selectedPizza = new SelectPizzaViewModel()
            {
                Pizza = _pizzaRepository.GetPizzaById(id),
                PizzaBase = _pizzaRepository.GetAllPizzaBase(),
                PizzaSize = _pizzaRepository.GetAllPizzaSize(),
                Toppings = _pizzaRepository.GetAllPizzaToppings(),
                AddOns = _pizzaRepository.GetAllPizzaAddOn()
            };

            OrderDetail orderDetail = new OrderDetail()
            {
                PizzaId = id

            };
            ViewBag.ActivateOrderButton = false;
            return View(selectedPizza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectedPizza(SelectPizzaViewModel selectedPizza)
        {
            if (!ModelState.IsValid) 
                return View(selectedPizza);

            ViewBag.ActivateOrderButton = true;

            selectedPizza.Pizza.Price += _pizzaRepository.GetPizzaCost(selectedPizza.Pizza);

            return RedirectToAction("Index","CustomerDetails", selectedPizza.Pizza);
        }
        
    }
}
