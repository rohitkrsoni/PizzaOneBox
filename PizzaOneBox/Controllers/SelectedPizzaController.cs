using Microsoft.AspNetCore.Mvc;
using PizzaOneBox.DataAccessLayer;
using PizzaOneBox.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace PizzaOneBox.Controllers
{
    public class SelectedPizzaController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;
        private static Pizza _selectedPizza;
        private static IList<AddOn> _addOns;
        private static IList<Topping> _toppings;
        private static IList<PizzaBase> _base;
        private static decimal _totalCost;
        public SelectedPizzaController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
            _addOns = _pizzaRepository.GetAddOnsList();
            _toppings = _pizzaRepository.GetToppingsList();
            _base = _pizzaRepository.GetPizzaBaseList();
        }
        [HttpGet]
        public IActionResult SelectedPizza(int id)
        {
            _selectedPizza = _pizzaRepository.GetPizza(id);
            _totalCost = _selectedPizza.DefaultCost;
            Order order = new Order() { AddOns = _addOns, Toppings = _toppings, Base = _base,TotalCost = _totalCost };
            SelectedPizzaViewModel model = new SelectedPizzaViewModel { pizza = _selectedPizza, order = order };
            ViewBag.ActivateOrderButton = false;
            return View(model);
        }
        [HttpPost]
        public IActionResult SelectedPizza(SelectedPizzaViewModel model)
        {
            model.pizza = _selectedPizza;
            for (int i = 0; i < model.order.AddOns.Count; i++)
            {
                _addOns[i].Selected = model.order.AddOns[i].Selected;
            }
            for (int i = 0; i < model.order.Toppings.Count; i++)
            {
                _toppings[i].Selected = model.order.Toppings[i].Selected;
            }
            model.order.Base = _base;
            model.order.AddOns = _addOns;
            model.order.Toppings = _toppings;

            if (!ModelState.IsValid) return View(model);
            ViewBag.ActivateOrderButton = true;
            _totalCost = _pizzaRepository.GetPizzaCost(model);

            model.order.TotalCost = _totalCost;
            return View(model);
        }
        [HttpPost]
        public IActionResult PlaceOrder(SelectedPizzaViewModel model)
        {
            model.pizza = _selectedPizza;
            for (int i = 0; i < model.order.AddOns.Count; i++)
            {
                _addOns[i].Selected = model.order.AddOns[i].Selected;
            }
            for (int i = 0; i < model.order.Toppings.Count; i++)
            {
                _toppings[i].Selected = model.order.Toppings[i].Selected;
            }
            model.order.Base = _base;
            model.order.AddOns = _addOns;
            model.order.Toppings = _toppings;
            model.order.TotalCost = _totalCost;
            if (!ModelState.IsValid) return View("SelectedPizza", model);
            string customerSelectesPizzaJson = JsonSerializer.Serialize(model);
            return RedirectToAction("Index", "CustomerDetails", new { customizedPizzaJson= customerSelectesPizzaJson });

        }
        
    }
}
