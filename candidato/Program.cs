using candidato.Business;
using candidato.Business.Strategys;
using candidato.Controllers;
using candidato.Controllers.Fachadas;
using candidato.DataAccess;
using candidato.DataAccess.daos;
using candidatos.Data;
using candidatos.Models;
using Microsoft.EntityFrameworkCore;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://example.com",
                                              "http://www.contoso.com");
                      });
});


//Definindo o acesso ao Banco de dados


var connectionString = builder.Configuration.GetConnectionString("CandidatoConnection");

builder.Services.AddDbContext<CandidatoContext>(opts =>
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var strategies = new List<IStrategy>();

// Adicionar suas strategies a Lista
strategies.Add(new ValidarCurso());
strategies.Add(new ValidarTelefone());
strategies.Add(new ValidarFormatoTelefone());
strategies.Add(new ValidarFiliacaoPai());
strategies.Add(new ValidarCamposVaziosNulos());


// Registrar a lista no contêiner
builder.Services.AddSingleton<List<IStrategy>>(strategies);

//Registrar injeções de dependencia no contêiner
builder.Services.AddScoped<IFachadaCandidato, FachadaCandidato>();
builder.Services.AddScoped<IDao, CandidatoDao>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
