using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaOneBox.DataAccessLayer;
using PizzaOneBox.Models;
using PizzaOneBox.ViewModel;
using System.Collections.Generic;

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
                // PizzaBase = _pizzaRepository.GetPizzaBaseById(id),
                // PizzaSize = _pizzaRepository.GetPizzaSizeById(id),
                Toppings = PopulateToppings(),
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

            return RedirectToAction("Index", "CustomerDetails", selectedPizza.Pizza);
        }

        private List<SelectListItem> PopulateToppings()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var toppings = _pizzaRepository.GetAllPizzaToppings();

            foreach (var topping in toppings)
            {
                items.Add(new SelectListItem
                {
                    Text = topping.Name,
                    Value = topping.Id.ToString()
                });
            }
            return items;
        }
    }
}
