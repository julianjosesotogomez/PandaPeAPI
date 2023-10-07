using Microsoft.EntityFrameworkCore;
using PandaPeAPI.Application;
using PandaPeAPI.Application.Interface;
using PandaPeAPI.DataAccess.Contexts;
using MediatR;
using AutoMapper;
using PandaPeAPI.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyeccion de despencencia de MediatR
builder.Services.AddMediatR(typeof(Program).Assembly);

//Inyeccion de dependencias de Aplication
builder.Services.AddScoped<ISelectionProcessApplication, SelectionProcessApplication>();


var stringconnectionBD = builder.Configuration.GetConnectionString("SQLDefaultConnection");
builder.Services.AddDbContext<SelectionProcessContext>(options => options.UseSqlServer(stringconnectionBD));

// Configuracion Automapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutomapperConfig());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

//Configuracion de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PoliticaCORS", x =>
    {
        x.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Habilitacion de politicas CORS
app.UseCors("PoliticaCORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
