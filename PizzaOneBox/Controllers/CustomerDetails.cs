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
        public IActionResult Index()
        {
            return View(new CustomerDetailsModel());
        }

    }
}
