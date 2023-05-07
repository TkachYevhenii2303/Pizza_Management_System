using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Management_System_DAL.Entities
{
    public class Pizza : Entity
    {
        public string? Pizza_title { get; set; }

        public Sauce? Sauce { get; set; }

        public ICollection<Topping> Toppings { get; set; } = null!;
    }
}
