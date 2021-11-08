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
        private static List<AddOn> _addOns;
        private static List<Topping> _toppings;
        public SelectedPizzaController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
            _addOns = _pizzaRepository.GetAvailableAddOns();
            _toppings = _pizzaRepository.GetAvailableToppings();
        }
        [HttpGet]
        public IActionResult SelectedPizza(int id)
        {
            _selectedPizza = _pizzaRepository.GetPizzaById(id);
            _selectedPizza.Toppings = _toppings;
            _selectedPizza.AddOns = _addOns;
            ViewBag.ActivateOrderButton = false;
            return View(_selectedPizza);
        }
        [HttpPost]
        public IActionResult SelectedPizza(Pizza userInput)
        {
            _selectedPizza.PizzaBaseId = userInput.PizzaBaseId;
            _selectedPizza.PizzaSizeId = userInput.PizzaSizeId;
            for (int i = 0; i < userInput.AddOns.Count; i++)
            {
                _selectedPizza.AddOns[i].Selected = userInput.AddOns[i].Selected;
            }
            for (int i = 0; i < userInput.Toppings.Count; i++)
            {
                _selectedPizza.Toppings[i].Selected = userInput.Toppings[i].Selected;
            }
            if (!ModelState.IsValid) return View(_selectedPizza);
            ViewBag.ActivateOrderButton = true;
            _selectedPizza.PizzaCost = _pizzaRepository.GetPizzaCost(_selectedPizza);
            return View(_selectedPizza);
        }
        [HttpPost]
        public IActionResult PlaceOrder(Pizza userInput)
        {
            string orderedPizzaDetailsJson = JsonSerializer.Serialize(_selectedPizza);
            return RedirectToAction("SaveOrderedPizzaDetails", "CustomerDetails", new { orderedPizzaDetailsJson = orderedPizzaDetailsJson });

        }
        
    }
}
