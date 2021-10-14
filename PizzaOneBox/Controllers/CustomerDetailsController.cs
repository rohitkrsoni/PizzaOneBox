using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaOneBox.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.Controllers
{
    public class CustomerDetailsController : Controller
    {

        [HttpGet]
        public IActionResult Index(Pizza selectedPizza)
        {
            var customerModel = new CustomerDetailsModel() { CustomerSelectedPizza = selectedPizza };
            return View(customerModel);
        }
        [HttpPost]
        public IActionResult Index(CustomerDetailsModel customerDetails)
        {
            return RedirectToAction("Index", "ConfirmationPg", customerDetails);
        }
    }
}
