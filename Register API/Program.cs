using Register_API.Data_Context;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SQLite;

var builder = WebApplication.CreateBuilder(args);


//// Add configuration
//var configuration = new ConfigurationBuilder()
//    .AddJsonFile("appsettings.json")
//    .Build();

//// Read the connection string from appsettings.json
//string connectionString = configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Register SQLite connection
builder.Services.AddScoped<SQLiteConnection>(_ => new SQLiteConnection());
// Register DatabaseManager with the connection string
builder.Services.AddSingleton(new DatabaseManager());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
