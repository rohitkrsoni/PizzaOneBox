using Microsoft.AspNetCore.Mvc;
using PizzaOneBox.Models;
using System;
using System.Text.Json;


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
            if (customerDetails.CustomerSelectedPizza.PizzaCost >= 20m)
            {
                ViewBag.Discount = Math.Round((customerDetails.CustomerSelectedPizza.PizzaCost * 0.15m),2);
                customerDetails.CustomerSelectedPizza.PizzaCost -=
                    customerDetails.CustomerSelectedPizza.PizzaCost * 0.15m;
                customerDetails.CustomerSelectedPizza.PizzaCost = Math.Round(customerDetails.CustomerSelectedPizza.PizzaCost, 2);
            }

            return View("ConfirmationPg",customerDetails);
        }

    }
}
