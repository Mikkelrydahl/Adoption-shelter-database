using AnimalAdoptionAPI.Controllers;
using AnimalAdoptionAPI.Services;
using AnimalAdoptionAPI.Interfaces;
using AnimalAdoptionAPI;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Neo4j.Driver;
using AnimalAdoptionAPI.Neo4JServices;
using MongoDB.Driver;
using AnimalAdoptionAPI.MongodbServices;


var builder = WebApplication.CreateBuilder(args);

Env.Load();
//Mysql connection string
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

builder.Services.AddDbContext<AnimalAdoptionDbContext>(options =>
    options.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

//Neo4j connection string
var neo4jconnectionstring = Environment.GetEnvironmentVariable("NEO4J_CONNECTION_STRING");
var neo4jusername = Environment.GetEnvironmentVariable("NEO4JUSERNAME");
var neo4jpassword = Environment.GetEnvironmentVariable("NEO4JPASSWORD");

var neo4jSettings = builder.Configuration.GetSection(neo4jconnectionstring);
var driver = GraphDatabase.Driver(
    neo4jconnectionstring,
    AuthTokens.Basic(neo4jusername, neo4jpassword)
);

builder.Services.AddScoped<Neo4jService>();
builder.Services.AddSingleton(driver);

//MongoDB connection
var mongodbConnectionstring = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING");

var MongoClient = new MongoClient(mongodbConnectionstring);
var MongoDatabase = MongoClient.GetDatabase("Animal_Adoption_ShelterDB");
builder.Services.AddScoped<MongodbService>();
builder.Services.AddSingleton(MongoDatabase);





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
