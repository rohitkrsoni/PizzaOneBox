using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaOneBox.Models;
using PizzaOneBox.ViewModel;
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
        public IActionResult Index(OrderDetail orderDetail)
        {
            //var customerDetails = new CustomerDetailsModel() 
            //{ CustomerSelectedPizza =  };

            var customerOrder = new CustomerOrderViewModel()
            {
                OrderDetail = orderDetail
            };
            return View(customerOrder);
        }

        [HttpPost]
        public IActionResult Index(CustomerOrderViewModel customerOrder)
        {
            Order order = new Order()
            {
               Date = DateTime.Now, 
               Customer = JsonSerializer.Serialize<CustomerDetailsModel>(customerOrder.CustomerDetails) 
            };

            var orderDetails = new OrderDetail()
            {
                Pizza = customerOrder.OrderDetail.Pizza,
                //TotalCost = customerOrder.OrderDetail.Pizza
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            var orderView = new OrderViewModel()
            {
                OrderToJson = JsonSerializer.Serialize<Order>(order, options),
                OrderDetailToJson = JsonSerializer.Serialize<OrderDetail>(orderDetails)
            };

            return RedirectToAction("Index", "ConfirmationPg", orderView);
        }
    }
}
