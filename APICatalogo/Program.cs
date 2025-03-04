using APICatalogo.Context;
using APICatalogo.DTOs.Mappings;
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
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepositoryImpl<>));
builder.Services.AddScoped<ICategoryRepository, CategoryRepositoryImpl>();
builder.Services.AddScoped<IProductRepository, ProductRepositoryImpl>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWorkImpl>();

builder.Services.AddAutoMapper(typeof(DomainToDTOMappingProfile).Assembly);

var app = builder.Build();

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