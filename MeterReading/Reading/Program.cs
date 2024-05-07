using Reading.Application;
using Reading.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddTransient<IProcessor, Processor>();
builder.Services.AddTransient<IValidator, Validator>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
