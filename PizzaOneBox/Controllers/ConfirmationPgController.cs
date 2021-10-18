using Microsoft.AspNetCore.Mvc;
using PizzaOneBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PizzaOneBox.Controllers
{
    public class ConfirmationPgController : Controller
    {
        [HttpGet]
        public IActionResult Index(CustomerDetailsModel customerDetails)
        {
            customerDetails.CustomerSelectedPizza = JsonSerializer.Deserialize<Pizza>(customerDetails.CustomerSelectedPizzaJson);
            Random r = new Random();
            ViewBag.Discount = 0;
            customerDetails.OrderId = r.Next()%1000000; //Model "order " store all info displayed
            if (customerDetails.CustomerSelectedPizza.TotalCost >= 20m)
            {
                ViewBag.Discount = customerDetails.CustomerSelectedPizza.TotalCost * 0.15m;
                customerDetails.CustomerSelectedPizza.TotalCost -=
                    customerDetails.CustomerSelectedPizza.TotalCost * 0.15m;
            }
            return View("ConfirmationPg",customerDetails);
        }
    }
}
