using Microsoft.EntityFrameworkCore;
using Pizza_Management_System_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Management_System_DAL.Context
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options) { }

        public DbSet<Pizza> Pizza { get; set; }

        public DbSet<Sauce> Sauces { get; set; }
        
        public DbSet<Topping> Toppings { get; set; }
    }
}
