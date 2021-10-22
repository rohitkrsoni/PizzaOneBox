using Microsoft.AspNetCore.Mvc;
using PizzaOneBox.Models;
using System;
using System.Text.Json;


namespace PizzaOneBox.Controllers
{
    public class ConfirmationPgController : Controller
    {
        
        [HttpPost]
        public ViewResult ConfirmationPg(CustomerDetailsModel customerDetail)
        {
            customerDetail.CustomerSelectedPizza = JsonSerializer.Deserialize<Pizza>(customerDetail.CustomerSelectedPizzaJson);
            Random r = new Random();
            ViewBag.Discount = 0;
            customerDetail.OrderId = r.Next() % 1000000; //Model "order " store all info displayed
            if (customerDetail.CustomerSelectedPizza.TotalCost >= 20m)
            {
                ViewBag.Discount = Math.Round((customerDetail.CustomerSelectedPizza.TotalCost * 0.15m), 2);
                customerDetail.CustomerSelectedPizza.TotalCost -=
                    customerDetail.CustomerSelectedPizza.TotalCost * 0.15m;
                customerDetail.CustomerSelectedPizza.TotalCost = Math.Round(customerDetail.CustomerSelectedPizza.TotalCost, 2);
            }

            return View(customerDetail);
        }
        

    }
}
