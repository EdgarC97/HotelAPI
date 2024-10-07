using System.Reflection;
using System.Text;
using DotNetEnv;
using HotelAPI.Config;
using HotelAPI.Data;
using HotelAPI.Interfaces;
using HotelAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

// Load environment variables using the Env.Load() method
Env.Load();

// Retrieve database connection details from environment variables
var dbHost = Environment.GetEnvironmentVariable("DB_HOST"); 
var dbPort = Environment.GetEnvironmentVariable("DB_PORT"); 
var dbDatabaseName = Environment.GetEnvironmentVariable("DB_DATABASE"); 
var dbUser = Environment.GetEnvironmentVariable("DB_USERNAME"); 
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

// Build the connection string for MySQL using the retrieved environment variables
var DefaultConnection = $"Host={dbHost};Database={dbDatabaseName};Username={dbUser};Password={dbPassword};Port={dbPort};";

// Create a builder for the web application
var builder = WebApplication.CreateBuilder(args);

// Configure Entity Framework Core to use MySQL with the constructed connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(DefaultConnection, new MySqlServerVersion(new Version(8, 0))));

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
builder.Services.AddScoped<IRoomService, RoomService>(); // Room service registration
builder.Services.AddScoped<IAuthService, AuthService>(); // Auth service registration
builder.Services.AddScoped<IGuestService, GuestService>(); // Guest service registration
builder.Services.AddScoped<IBookingService, BookingService>(); // Booking service registration

// Add services to the container
builder.Services.AddControllers(); // Add controllers for API endpoints
builder.Services.AddEndpointsApiExplorer(); // Add support for endpoint exploration
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HOTEL API ", Version = "v1" }); // Configure Swagger documentation

    // Include XML comments for Swagger
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; // Get the XML documentation file name
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile); // Set the path for XML file
    c.IncludeXmlComments(xmlPath); // Include the XML comments in Swagger

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

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment()) // Check if the environment is development
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
