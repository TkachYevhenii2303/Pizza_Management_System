using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pizza_Management_System_DAL.Context;
using Pizza_Management_System_DAL.Seeding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Management_System_DAL.Extensions
{
    public static class Extensions
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    
                    var context = services.GetRequiredService<PizzaContext>();
                    
                    context.Database.EnsureCreated();

                    Seeding_Database.Initialize(context);
                }
            }
        }
    }
}
