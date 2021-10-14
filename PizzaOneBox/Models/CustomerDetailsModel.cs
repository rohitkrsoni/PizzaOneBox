using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaOneBox.Models
{
    public class CustomerDetailsModel
    {
        public Pizza CustomerSelectedPizza { get; set; }
        public int OrderId { get; set; }
        [Required(ErrorMessage ="Please enter your name")]
        [MinLength(2,ErrorMessage ="Name length should be of minimum 2 characters")]
        [MaxLength(20,ErrorMessage ="Name length should be of maximum 20 characters")]
        public string CustomerName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage ="Please enter your PhoneNumber")]
        public string CustomerPhoneNumber { get; set; }

        [Required(ErrorMessage ="Please enter your address")]
        public string CustomerAddress { get; set; }
    }
}
