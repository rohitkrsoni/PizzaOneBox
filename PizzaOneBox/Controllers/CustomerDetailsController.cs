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
        [HttpGet]
        public IActionResult Index(Pizza selectedPizza)
        {
            var customerDetails = new CustomerDetailsModel() 
            { CustomerSelectedPizzaJson = JsonSerializer.Serialize(selectedPizza) };
            return View(customerDetails);
        }
        [HttpPost]
        public IActionResult Index(CustomerDetailsModel customerDetails)
        {
            return RedirectToAction("Index", "ConfirmationPg", customerDetails);
        }
    }
}
