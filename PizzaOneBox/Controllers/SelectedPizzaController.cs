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
            OrderedPizzaDetails orderedPizzaDetails = new OrderedPizzaDetails() {SelectedPizza = _selectedPizza, AddOns = _addOns, Toppings = _toppings, Base = _base,TotalCost = _totalCost };
            ViewBag.ActivateOrderButton = false;
            return View(orderedPizzaDetails);
        }
        [HttpPost]
        public IActionResult SelectedPizza(OrderedPizzaDetails orderedPizzaDetails)
        {
            orderedPizzaDetails.SelectedPizza = _selectedPizza;
            for (int i = 0; i < orderedPizzaDetails.AddOns.Count; i++)
            {
                _addOns[i].Selected = orderedPizzaDetails.AddOns[i].Selected;
            }
            for (int i = 0; i < orderedPizzaDetails.Toppings.Count; i++)
            {
                _toppings[i].Selected = orderedPizzaDetails.Toppings[i].Selected;
            }
            orderedPizzaDetails.Base = _base;
            orderedPizzaDetails.AddOns = _addOns;
            orderedPizzaDetails.Toppings = _toppings;

            if (!ModelState.IsValid) return View(orderedPizzaDetails);
            ViewBag.ActivateOrderButton = true;
            _totalCost = _pizzaRepository.GetPizzaCost(orderedPizzaDetails);

            orderedPizzaDetails.TotalCost = _totalCost;
            return View(orderedPizzaDetails);
        }
        [HttpPost]
        public IActionResult PlaceOrder(OrderedPizzaDetails orderedPizzaDetails)
        {
            orderedPizzaDetails.SelectedPizza = _selectedPizza;
            for (int i = 0; i < orderedPizzaDetails.AddOns.Count; i++)
            {
                _addOns[i].Selected = orderedPizzaDetails.AddOns[i].Selected;
            }
            for (int i = 0; i < orderedPizzaDetails.Toppings.Count; i++)
            {
                _toppings[i].Selected = orderedPizzaDetails.Toppings[i].Selected;
            }
            orderedPizzaDetails.Base = _base;
            orderedPizzaDetails.AddOns = _addOns;
            orderedPizzaDetails.Toppings = _toppings;
            orderedPizzaDetails.TotalCost = _totalCost;
            if (!ModelState.IsValid) return View("SelectedPizza", orderedPizzaDetails);
            string orderedPizzaDetailsJson = JsonSerializer.Serialize(orderedPizzaDetails);

            return RedirectToAction("SaveOrderedPizzaDetails", "CustomerDetails", new { orderedPizzaDetailsJson = orderedPizzaDetailsJson });

        }
        
    }
}
