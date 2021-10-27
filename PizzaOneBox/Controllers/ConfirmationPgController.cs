using Microsoft.AspNetCore.Mvc;
using PizzaOneBox.Models;
using System;
using System.Text.Json;


namespace PizzaOneBox.Controllers
{
    public class ConfirmationPgController : Controller
    {
        [HttpGet]
        public IActionResult Index(string orderDetails)
        {
            var customerDetails = JsonSerializer.Deserialize<CustomerDetailsModel>(orderDetails);
            customerDetails.CustomerSelectedPizza = JsonSerializer.Deserialize<SelectedPizzaViewModel>(customerDetails.CustomerSelectedPizzaJson);
            Random r = new Random();
            ViewBag.Discount = 0;
            customerDetails.OrderId = r.Next()%1000000; //Model "order " store all info displayed
            if (customerDetails.CustomerSelectedPizza.order.TotalCost >= 20m)
            {
                ViewBag.Discount = Math.Round((customerDetails.CustomerSelectedPizza.order.TotalCost * 0.15m),2);
                customerDetails.CustomerSelectedPizza.order.TotalCost -=
                    customerDetails.CustomerSelectedPizza.order.TotalCost * 0.15m;
                customerDetails.CustomerSelectedPizza.order.TotalCost = Math.Round(customerDetails.CustomerSelectedPizza.order.TotalCost, 2);
            }

            return View("ConfirmationPg",customerDetails);
        }

    }
}
