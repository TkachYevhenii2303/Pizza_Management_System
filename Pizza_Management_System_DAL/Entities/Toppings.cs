using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pizza_Management_System_DAL.Entities
{
    public class Topping : Entity
    {
        public string? Topping_title { get; set; }

        public decimal Calories { get; set; }

        [JsonIgnore]
        public ICollection<Pizza> Pizzas { get; set; } = null!;
    }
}
