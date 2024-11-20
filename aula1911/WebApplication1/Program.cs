using GestaoFacil.DataContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // sem esse método não há reconhecimento dos controllers

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Busca string de conexão e adiciona a classe AppDbContext Service do Entity Framework
var connectionString = builder.Configuration.GetConnectionString("default"); // conexão ao bd
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseAuthorization();
app.UseHttpsRedirection(); // redirecionar todas as requisições HTTP para HTTPS
app.MapControllers(); // mapeia os controladores para as rotas
app.Run(); // inicia o aplicativo




