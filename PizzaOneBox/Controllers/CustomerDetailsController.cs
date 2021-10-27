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
        public IActionResult Index(string customizedPizzaJson)
        {
            _selectedPizzaViewModelJson = customizedPizzaJson;
            return View("Index");
        }
        [HttpPost]
        public IActionResult Index(CustomerDetailsModel customerDetails)
        {
            customerDetails.CustomerSelectedPizzaJson = _selectedPizzaViewModelJson;
            return RedirectToAction("Index", "ConfirmationPg", new { orderDetails = JsonSerializer.Serialize(customerDetails)  });
        }
       
    }
}
