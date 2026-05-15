using Autogermana.Application.Interfaces;
using Autogermana.Application.services;
using Autogermana.Domain.Entities;
using Autogermana.Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IErrorService, ErrorService>();

builder.Services.Configure<AuthSettings>(
        builder.Configuration.GetSection("AuthSettings"));


builder.Services.AddHttpClient<IPowerService, PowerService>(option =>
{
    option.Timeout = TimeSpan.FromSeconds(30);
});

builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
var app = builder.Build();

app.MapSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
