using Pizza_Management_System_DAL.Context;
using Pizza_Management_System_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Management_System_DAL.Seeding
{
    public class Seeding_Database
    {
        public static void Initialize(PizzaContext context)
        {

            if (context.Pizza.Any() && context.Toppings.Any() && context.Sauces.Any()) { return; }

            var pepperoniTopping = new Topping { Topping_title = "Pepperoni", Calories = 130 };
            var sausageTopping = new Topping { Topping_title = "Sausage", Calories = 100 };
            var hamTopping = new Topping { Topping_title = "Ham", Calories = 70 };
            var chickenTopping = new Topping { Topping_title = "Chicken", Calories = 50 };
            var pineappleTopping = new Topping { Topping_title = "Pineapple", Calories = 75 };

            var tomatoSauce = new Sauce { Sauce_title = "Tomato", Is_vegan = true };
            var alfredoSauce = new Sauce { Sauce_title = "Alfredo", Is_vegan = false };

            var pizzas = new Pizza[]
            {
                new Pizza
                    {
                        Pizza_title = "Meat Lovers",
                        Sauce = tomatoSauce,
                        Toppings = new List<Topping>
                            {
                                pepperoniTopping,
                                sausageTopping,
                                hamTopping,
                                chickenTopping
                            }
                    },
                new Pizza
                    {
                        Pizza_title = "Hawaiian",
                        Sauce = tomatoSauce,
                        Toppings = new List<Topping>
                            {
                                pineappleTopping,
                                hamTopping
                            }
                    },
                new Pizza
                    {
                        Pizza_title="Alfredo Chicken",
                        Sauce = alfredoSauce,
                        Toppings = new List<Topping>
                            {
                                chickenTopping
                            }
                        }
            };

            context.Pizza.AddRange(pizzas);
            context.SaveChanges();
        }
    }
}
