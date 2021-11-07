using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaOneBox.DataAccessLayer;
using PizzaOneBox.Models;
using PizzaOneBox.ViewModels;
using System.Collections.Generic;

namespace PizzaOneBox.Controllers
{
    public class SelectedPizzaController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;
        private static Pizza _selectedPizza;
        private List<SelectListItem> _toppingsSelectList;
        private List<SelectListItem> _addOnsSelectList;
        public SelectedPizzaController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
            _toppingsSelectList = populateToppings();
            _addOnsSelectList = populateAddons();
        }
        [HttpGet]
        public IActionResult SelectedPizza(int id)
        {
            _selectedPizza = _pizzaRepository.GetPizzaById(id);
            SelectedPizzaViewModel selectedPizza = new SelectedPizzaViewModel()
            {
                Pizza = _selectedPizza,
                Toppings = _toppingsSelectList,
                AddOns = _addOnsSelectList
            };

            ViewBag.ActivateOrderButton = false;
            return View("SelectedPizza",selectedPizza);
        }
        [HttpPost]
        public IActionResult SelectedPizza(SelectedPizzaViewModel userInput)
        {
            _selectedPizza.PizzaBaseId = userInput.Pizza.PizzaBaseId;
            _selectedPizza.PizzaSizeId = userInput.Pizza.PizzaSizeId;
            _selectedPizza.PizzaCost = _pizzaRepository.GetPizzaCost(_selectedPizza);
            SelectedPizzaViewModel selectedPizza = new SelectedPizzaViewModel()
            {
                Pizza = _selectedPizza,
                // PizzaBase = _pizzaRepository.GetPizzaBaseById(id),
                // PizzaSize = _pizzaRepository.GetPizzaSizeById(id),
                // Toppings = PopulateToppings(),
                // AddOns = PopulateAddOns()
            };
            return View("SelectedPizza", selectedPizza);
        }

        private List<SelectListItem> populateToppings()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var toppings = _pizzaRepository.GetAvailableToppings();

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
        private List<SelectListItem> populateAddons()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var addOns = _pizzaRepository.GetAvailableAddOns();
            foreach (var addOn in addOns)
            {
                items.Add(new SelectListItem
                {
                    Text = addOn.AddOnName,
                    Value = addOn.Id.ToString()
                });
            }
            return items;
        }

    }
}
