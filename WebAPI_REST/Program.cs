using Microsoft.EntityFrameworkCore;
using WebAPI_REST.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AsteroidsContext>(options => //options sera tot lo que surti de la següen linea
options.UseSqlServer(
    builder.Configuration.GetConnectionString("AsteroidsContext")));// Injeccio de dependencias

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
