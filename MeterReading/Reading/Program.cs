using Reading.Application;
using Reading.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IReadingRepository, ReadingRepository>();
builder.Services.AddTransient<IReadingProcessor, ReadingProcessor>();
builder.Services.AddTransient<IAccountProcessor, AccountProcessor>();
builder.Services.AddTransient<IAccountValidator, AccountValidator>();
builder.Services.AddTransient<IReadingValidator, ReadingValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
