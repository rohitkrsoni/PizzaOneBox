using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaOneBox.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PizzaOneBox.Controllers
{
    public class CustomerDetailsController : Controller
    {
        private static string _selectedPizzaJson;
        [HttpGet]
        public IActionResult SaveOrderedPizzaDetails(string orderedPizzaDetailsJson)
        {
            _selectedPizzaJson = orderedPizzaDetailsJson;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        public IActionResult Index(CustomerDetailsModel customerDetails)
        {
            Order order = new Order()
            {
                Pizza = JsonSerializer.Deserialize<Pizza>(_selectedPizzaJson),
                CustomerDetails = customerDetails
            };
            return RedirectToAction("SaveOrder", "ConfirmationPg", new { order = JsonSerializer.Serialize(order)  });
        }
       
    }
}
