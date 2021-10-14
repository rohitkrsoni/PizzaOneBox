using Microsoft.AspNetCore.Mvc;
using PizzaOneBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.Controllers
{
    public class ConfirmationPgController : Controller
    {
        [HttpGet]
        public IActionResult Index(CustomerDetailsModel customerDetails)
        {
            Random r = new Random();
            
            customerDetails.OrderId = r.Next()%1000000; //Model "order " store all info displayed
            if (customerDetails.CustomerSelectedPizza.TotalCost >= 20m)
            {
                ViewBag.Message = String.Format("Congratulations you are served with 15% discount!!!");
                customerDetails.CustomerSelectedPizza.TotalCost -=
                    customerDetails.CustomerSelectedPizza.TotalCost * 0.15m;
            }
            return View(customerDetails);
        }
    }
}
