using Microsoft.EntityFrameworkCore;
using MTGCollectionApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var host = Environment.GetEnvironmentVariable("ENV_HOST");
var database = Environment.GetEnvironmentVariable("ENV_DATABASE");
var username = Environment.GetEnvironmentVariable("ENV_USER");
var password = Environment.GetEnvironmentVariable("ENV_PASSWORD");
var port = Environment.GetEnvironmentVariable("ENV_PORT");

var connectionString = $"Host={host};Database={database};Username={username};Password={password};Port={port}";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

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
