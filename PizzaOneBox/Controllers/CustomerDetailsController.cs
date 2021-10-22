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
        [HttpPost]
        public IActionResult PlaceOrder(Pizza finalPizza)
        {
            var customerDetail = new CustomerDetailsModel()
            { CustomerSelectedPizzaJson = JsonSerializer.Serialize(finalPizza) };
            return View("~/Views/CustomerDetails/Index.cshtml", customerDetail);
        }
       
    }
}
