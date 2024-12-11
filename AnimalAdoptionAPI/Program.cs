using AnimalAdoptionAPI.Controllers;
using AnimalAdoptionAPI.Services;
using AnimalAdoptionAPI.Interfaces;
using AnimalAdoptionAPI;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;


var builder = WebApplication.CreateBuilder(args);

Env.Load();
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

builder.Services.AddDbContext<AnimalAdoptionDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the AdoptionService for dependency injection
builder.Services.AddSingleton<AdoptionService>();

// Add controllers to handle API routes (this automatically includes AdoptionController)
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
