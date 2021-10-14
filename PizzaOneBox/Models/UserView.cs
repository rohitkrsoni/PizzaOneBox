using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PizzaOneBox.Models
{
    public class UserView
    {
        [Required(ErrorMessage ="Please enter your name")]
        public string UserName { get; set; }
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Please provide your contact number")]
        public int UserPhoneNumber { get; set; }
        [Required(ErrorMessage = "Please provide your address")]
        public string UserAddress { get; set; }

        public int OrderId { get; set; }

        public decimal PizzaPrize { get; set; }
    }
}
