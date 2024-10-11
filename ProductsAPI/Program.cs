using System.Text;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProductsAPI.Config;
using ProductsAPI.Data;
using ProductsAPI.Interfaces;
using ProductsAPI.Services;

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
    options.UseMySql(DefaultConnection, new MySqlServerVersion(new Version(8, 10))));

// Configuring JSON Web Token (JWT) authentication
builder.Services.AddSingleton<Utilities>(); // Register Utilities as a singleton
builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // Default scheme for authentication
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // Default scheme for challenges
    config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; // Default scheme
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false; // Allow HTTP for testing purposes
    config.SaveToken = true; // Save the token
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, // Validate the token's issuer
        ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"), // Set valid issuer from environment
        ValidateAudience = false, // Audience validation is disabled
        ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"), // Set valid audience from environment
        ValidateLifetime = true, // Validate token lifetime
        ClockSkew = TimeSpan.Zero, // No clock skew
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY")!)) // Set signing key from environment
    };
});


// Register application services
builder.Services.AddScoped<ICategoryService, CategoryService>(); // Category service registration
builder.Services.AddScoped<IProductService, ProductService>(); // Product service registration
builder.Services.AddScoped<IOrderService, OrderService>(); // Order service registration
builder.Services.AddScoped<IAuthService, AuthService>(); // Auth service registration

// Add services to the container
builder.Services.AddControllers(); // Add controllers for API endpoints
builder.Services.AddEndpointsApiExplorer(); // Add support for endpoint exploration
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Products and orders management system - API", Version = "v1" });
    // Customize Swagger UI settings here.
    c.EnableAnnotations();

    // Configure security definition for JWT in Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Name = "Authorization", // Name of the header
        In = ParameterLocation.Header, // Location of the header
        Type = SecuritySchemeType.Http, // Type of security scheme
        Scheme = "Bearer" // Scheme name
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer" // Reference to the security scheme
                }
            },
            new string[] {} // No specific scopes required
        }
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.UseWelcomePage(new WelcomePageOptions
{
    Path = "/"
});

// Run the application
app.Run();
