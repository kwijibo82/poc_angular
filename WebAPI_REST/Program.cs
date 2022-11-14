using Microsoft.EntityFrameworkCore;
using WebAPI_REST.Models;

var builder = WebApplication.CreateBuilder(args);

// Establir connexió a la base de dades, en aquest cas, SQL Server
builder.Services.AddDbContext<AsteroidsContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("AsteroidsContext") // Injecció de dependències (DI)
));

builder.Services.AddDbContext<LlibreContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("LlibreContext") // Injecció de dependències (DI)
));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); //
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
