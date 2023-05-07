using Microsoft.EntityFrameworkCore;
using Pizza_Management_System_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Management_System_BLL.Services.Interfaces
{
    public interface IPizzaServices
    {
        public Task<IEnumerable<Pizza>> Get_all_Pizza();

        public Task<Pizza> Get_the_Pizza(Guid ID);

        public Task<Pizza> Insert_Pizza(Pizza pizza);

        public Task Update_Sauce(Guid pizza_ID, Guid sauce_ID);

        public Task Insert_Topping(Guid pizza_ID, Guid topping_ID);

        public Task Delete_Pizza_ID(Guid ID);
    }
}
