using Microsoft.EntityFrameworkCore;
using Pizza_Management_System_BLL.Services.Interfaces;
using Pizza_Management_System_DAL.Context;
using Pizza_Management_System_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Management_System_BLL.Services
{
    public class PizzaServices : IPizzaServices
    {
        private readonly PizzaContext _context;

        public PizzaServices(PizzaContext context) => _context = context;

        public async Task<IEnumerable<Pizza>> Get_all_Pizza()
        {
            return await _context.Pizza.AsNoTracking().ToListAsync();
        }

        public async Task<Pizza> Get_the_Pizza(Guid ID)
        {
            var result = await _context.Pizza
                .Include(p => p.Toppings)
                .Include(p => p.Sauce)
                .AsNoTracking().SingleOrDefaultAsync(x => x.ID == ID);

            if (result is null)
            {
                throw new NullReferenceException($"The Pizza with {ID} ID was not found!!!");
            }

            return result;
        }

        public async Task<Pizza> Insert_Pizza(Pizza pizza)
        {
            await _context.Pizza.AddAsync(pizza);

            await _context.SaveChangesAsync();

            return pizza;
        }

        public async Task Update_Sauce(Guid pizza_ID, Guid sauce_ID)
        {
            var pizza_to_Updating = await _context.Pizza.FindAsync(pizza_ID);

            var sauce_to_Updating = await _context.Sauces.FindAsync(sauce_ID);

            if (pizza_to_Updating is null || sauce_to_Updating is null)
            {
                throw new InvalidOperationException("Pizza or sauce does not exist");
            }

            pizza_to_Updating.Sauce = sauce_to_Updating;

            await _context.SaveChangesAsync();
        }

        public async Task Insert_Topping(Guid pizza_ID, Guid topping_ID)
        {
            var pizza_to_Updating = await _context.Pizza.FindAsync(pizza_ID);

            var topping_to_Updating = await _context.Toppings.FindAsync(topping_ID);

            if (pizza_to_Updating is null || topping_to_Updating is null)
            {
                throw new InvalidOperationException("Pizza or topping does not exist");
            }

            if (pizza_to_Updating.Toppings is null)
            {
                pizza_to_Updating.Toppings = new List<Topping>();
            }

            pizza_to_Updating.Toppings.Add(topping_to_Updating);

            await _context.SaveChangesAsync();
        }

        public async Task Delete_Pizza_ID(Guid ID)
        {
            var pizza_to_Deleting = await _context.Pizza.FindAsync(ID);

            if (pizza_to_Deleting is not null)
            {
                _context.Pizza.Remove(pizza_to_Deleting);

                await _context.SaveChangesAsync();
            }
        }
    }
}
