using Microsoft.EntityFrameworkCore;
using WebAPI_REST.Models;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200");
                      });
});

builder.Services.AddDbContext<AsteroidsContext>(options => //options sera tot lo que surti de la seg?en linea
options.UseSqlServer(
    builder.Configuration.GetConnectionString("AsteroidsContext")));// Injeccio de dependencias

builder.Services.AddDbContext<HeroesContext>(options => 
options.UseSqlServer(
    builder.Configuration.GetConnectionString("HeroesContext")));


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


app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
