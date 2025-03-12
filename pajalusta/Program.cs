using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VintageCarGarageAPI.Data;
using VintageCarGarageAPI.Repositories;
using VintageCarGarageAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add database context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<InsideBoxContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add JWT authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key is missing in configuration.")))
        };
    });

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Add services to the container
builder.Services.AddScoped<CarRepository>();
builder.Services.AddScoped<CarService>();
builder.Services.AddScoped<ServiceRepository>();
builder.Services.AddScoped<ServiceService>();

builder.Services.AddControllers();

var app = builder.Build();

// Apply CORS policy before Authentication
app.UseCors("AllowAllOrigins");

// Use DeveloperExceptionPage in development for detailed error logs
if (app.Environment.IsDevelopment())
{
    // The error page will automatically work if no external package is referenced
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// HTTPS redirection (only for development environments, commented out for other environments)
app.UseHttpsRedirection();

app.UseStaticFiles();

// Authentication & Authorization middleware
app.UseAuthentication();
app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();
