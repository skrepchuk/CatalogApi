using APICatalogo.Context;
using APICatalogo.Extensions;
using APICatalogo.Filters;
using APICatalogo.Repositories;
using APICatalogo.RepositoryImpl;
using APICatalogo.Services;
using APICatalogo.ServicesImpl;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(o =>
{
    o.Filters.Add<ApiLoggingFilter>();
    o.Filters.Add<ApiExceptionFilter>();
}).AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mysqlConnectionString = builder.Configuration.GetConnectionString("APICatalog");

builder.Services.AddDbContext<APICatalogContext>(o =>
    o.UseMySql(mysqlConnectionString,
        ServerVersion.AutoDetect(mysqlConnectionString)));

builder.Services.AddScoped<ApiLoggingFilter>();
builder.Services.AddTransient<IMyService, MyService>();
builder.Services.AddScoped<ICategorieRepository, CategoryRepositoryImpl>();
builder.Services.AddScoped<IProductRepository, ProductRepositoryImpl>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();