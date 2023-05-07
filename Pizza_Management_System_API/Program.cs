using Microsoft.EntityFrameworkCore;
using Pizza_Management_System_DAL.Context;
using Pizza_Management_System_DAL.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PizzaContext>(configuration =>
{
    configuration.UseSqlServer(builder.Configuration.GetConnectionString("Pizza_connections"), 
        options => options.MigrationsAssembly("Pizza_Management_System_API"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

//app.CreateDbIfNotExists();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();