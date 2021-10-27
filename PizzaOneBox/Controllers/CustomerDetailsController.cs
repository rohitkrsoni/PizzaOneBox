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
        private static string _selectedPizzaViewModelJson;
        [HttpGet]
        public IActionResult SaveOrderedPizzaDetails(string orderedPizzaDetailsJson)
        {
            _selectedPizzaViewModelJson = orderedPizzaDetailsJson;
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
            customerDetails.OrderedPizzaDetailsJson = _selectedPizzaViewModelJson;
            return RedirectToAction("SaveCustomerDetails", "ConfirmationPg", new { orderDetails = JsonSerializer.Serialize(customerDetails)  });
        }
       
    }
}
