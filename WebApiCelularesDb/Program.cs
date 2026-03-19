using Microsoft.EntityFrameworkCore;
using WebApiCelularesDb.Features.Celulares.AppServices;
using WebApiCelularesDb.Features.Celulares.DomainServices;
using WebApiCelularesDb.Features.Celulares.Interfaces;
using WebApiCelularesDb.Infrastucture.Databases;
using WebApiCelularesDb.Infrastucture.Interfaces;
using WebApiCelularesDb.Infrastucture.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Base de datos
builder.Services.AddDbContext<CelularesDbContext>
    (options =>
    options.UseSqlServer(
    builder.Configuration.GetConnectionString(
        "DbCelularesConnectionString"
        )
    )
);


//Servicios

builder.Services.AddScoped<ICelularesRepository, CelularesRepository>();
builder.Services.AddScoped<ICategoriasRepository, CategoriasRepository>();
builder.Services.AddScoped<ICelularesAppService, CelularesAppService>();
builder.Services.AddScoped<ICategoriasAppService, CategoriasAppService>();
builder.Services.AddScoped<CelularesDomainService>();
builder.Services.AddScoped<CategoriasDomainService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
