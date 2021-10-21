using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaOneBox.DataAccessLayer;
using PizzaOneBox.Models;
using PizzaOneBox.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

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
                AddOns = PopulateAddOns()
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
        public IActionResult SelectedPizza(SelectPizzaViewModel selectedPizza, string[] toppings, string[] addOns)
        {
            if (!ModelState.IsValid)
                return View(selectedPizza);

            selectedPizza.Toppings = PopulateToppings();

            foreach (SelectListItem topping in selectedPizza.Toppings)
            {
                if (toppings.Contains(topping.Value))
                {
                    selectedPizza.Pizza.ToppingsId.Add(topping.Value);
                }
            }

            if (addOns.Length > 0)
            {
                foreach (SelectListItem addOn in selectedPizza.AddOns)
                {
                    if (addOns.Contains(addOn.Value))
                    {
                        selectedPizza.Pizza.PizzaId += Convert.ToInt32(addOn.Value);
                    }
                }

            }

            ViewBag.ActivateOrderButton = true;

            selectedPizza.Pizza.Price += _pizzaRepository.GetPizzaCost(selectedPizza.Pizza);

            var orderDetails = new OrderDetail()
            {
                Pizza = JsonSerializer.Serialize<Pizza>(selectedPizza.Pizza),
                TotalCost = selectedPizza.Pizza.Price
            };

            return RedirectToAction("Index", "CustomerDetails", orderDetails);
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

        private List<SelectListItem> PopulateAddOns()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var addOns = _pizzaRepository.GetAllPizzaAddOn();

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
