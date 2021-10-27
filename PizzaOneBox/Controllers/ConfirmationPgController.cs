using Microsoft.AspNetCore.Mvc;
using PizzaOneBox.Models;
using System;
using System.Text.Json;


namespace PizzaOneBox.Controllers
{
    public class ConfirmationPgController : Controller
    {
        public static CustomerDetailsModel _customerDetails;
        [HttpGet]
        public IActionResult SaveCustomerDetails(string orderDetails)
        {
            _customerDetails = JsonSerializer.Deserialize<CustomerDetailsModel>(orderDetails);
            _customerDetails.OrderedPizzaDetails = 
                JsonSerializer.Deserialize<OrderedPizzaDetails>(_customerDetails.OrderedPizzaDetailsJson);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Index()
        {
            Random r = new Random();
            ViewBag.Discount = 0;
            _customerDetails.OrderId = r.Next()%1000000; //Model "order " store all info displayed
            if (_customerDetails.OrderedPizzaDetails.TotalCost >= 20m)
            {
                ViewBag.Discount = Math.Round((_customerDetails.OrderedPizzaDetails.TotalCost * 0.15m),2);
                _customerDetails.OrderedPizzaDetails.TotalCost -=
                    _customerDetails.OrderedPizzaDetails.TotalCost * 0.15m;
                _customerDetails.OrderedPizzaDetails.TotalCost = Math.Round(_customerDetails.OrderedPizzaDetails.TotalCost, 2);
            }
            return View("ConfirmationPg",_customerDetails);
        }

    }
}
