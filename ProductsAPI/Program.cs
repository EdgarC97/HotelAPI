using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Data;

// Load environment variables using the Env.File

Env.Load();

// Retrieve database connection details from environment variables
var dbHost = Environment.GetEnvironmentVariable("DB_HOST"); 
var dbPort = Environment.GetEnvironmentVariable("DB_PORT"); 
var dbDatabaseName = Environment.GetEnvironmentVariable("DB_DATABASE"); 
var dbUser = Environment.GetEnvironmentVariable("DB_USERNAME"); 
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

// Build the connection string for MySQL using the retrieved environment variables
var DefaultConnection = $"Host={dbHost};Database={dbDatabaseName};Username={dbUser};Password={dbPassword};Port={dbPort};";


var builder = WebApplication.CreateBuilder(args);

// Configure Entity Framework Core to use MySQL with the constructed connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(DefaultConnection, new MySqlServerVersion(new Version(8, 0))));

// Add services to the container.
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


app.Run();
