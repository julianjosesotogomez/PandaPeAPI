using Microsoft.EntityFrameworkCore;
using PandaPeAPI.Application;
using PandaPeAPI.Application.Interface;
using PandaPeAPI.DataAccess.Contexts;
using PandaPeAPI.Domain;
using PandaPeAPI.Domain.Interface;
using MediatR;
using AutoMapper;
using PandaPeAPI.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(Program).Assembly);

//Inyeccion de dependencias de Aplication
builder.Services.AddScoped<ISelectionProcessApplication, SelectionProcessApplication>();

//Inyeccion de dependencias de Domain
builder.Services.AddScoped<ISelectionProcessDomain, SelectionProcessDomain>();

//var stringconnectionBD = builder.Configuration.GetSection("ConnectionStrings").GetSection("SQLDefaultConnection").ToString();
builder.Services.AddDbContext<SelectionProcessContext>(options => options.UseSqlServer("Data Source=JULIANSOTOGOMEZ\\SQLEXPRESS;Initial Catalog=PandaPe;Integrated Security=false;User ID=sa; Password=Blink3027@;MultipleActiveResultSets=True;"));

// Configuracion Automapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutomapperConfig());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
