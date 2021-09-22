using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOneBox.Models
{
    public class PizzaModel
    { 
        
        public int PizzaId { get; set; }
        public String PizzaName { get; set; }
        public PizzaSize Size { get; set; }
        public float Cost { get; set; }
        public PizzaBase Base { get; set; }

        [Required(ErrorMessage ="Please Select At Least 1 Toppings")]
        public IEnumerable<Topping> Toppings { get; set; }

        public string Description { get; set; }

        public PizzaModel()
        {

        }

        public PizzaModel(int id,String name,PizzaSize size,float cost)
        {
            this.PizzaId = id;
            this.PizzaName = name;
            this.Size = size;
            this.Cost = cost;
        }

    }
}

