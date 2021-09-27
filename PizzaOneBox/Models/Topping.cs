using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.Models
{
    public class Topping
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool CheckBoxAnswer { get; set; }

        public Topping()
        {

        }

        public Topping(int id,string topping,decimal price,bool checkBoxAnswer=false)
        {
            this.Id = id;
            this.Name = topping;
            this.Price = price;
            this.CheckBoxAnswer = checkBoxAnswer;
        }
    }
}
