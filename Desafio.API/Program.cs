using Desafio.Infrastructure.CommandBus;
using Desafio.Infrastructure.Context.Interfaces;
using Desafio.Infrastructure.Context;
using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Desafio.Infrastructure.Repository.Interfaces;
using Desafio.Infrastructure.Repository;
using Desafio.API.Middleware;
using Desafio.Infrastructure.Queries;
using Desafio.Infrastructure.Queries.Interfaces;
using Desafio.Domain.Entities;
using Desafio.Application.Commands.Assuntos.CommandsHandlers;
using Desafio.Application.Commands.Assuntos.Validators;
using Desafio.Infrastructure.AutoMapper;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddFluentValidationRulesToSwagger();
builder.Services.AddValidatorsFromAssemblyContaining<AssuntoCommandValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Desafio.Api", Version = "v1" });    

    var currentAssembly = Assembly.GetExecutingAssembly();
    var xmlDocs = currentAssembly.GetReferencedAssemblies()
    .Union(new AssemblyName[] { currentAssembly.GetName() })
    .Select(file => Path.Combine(Path.GetDirectoryName(currentAssembly.Location)!, $"{file.Name}.xml"))
    .Where(f => File.Exists(f))
    .ToArray();

    Array.ForEach(xmlDocs, (string d) =>
    {
        c.IncludeXmlComments(d);
    });
});

builder.Services.AddCors(p => p.AddPolicy("CORS", builder =>
{
    builder
        .WithOrigins("http://localhost:4200")
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .WithExposedHeaders("Access-Control-Allow-Origin");
}));

builder.Services.AddDbContext<ApplicationDbContext>((provider, options) =>
{    
    options.UseSqlServer(configuration.GetConnectionString("Desafio"), x => x.MigrationsAssembly("Desafio.Infrastructure"));
});
builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped<ICommandBus, CommandBus>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IAssuntoRepository, AssuntoRepository>();
builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped(typeof(IQueryFacade<>), typeof(QueryFacade<>));
builder.Services.AddScoped<IQueryFacade<Assunto>, QueryFacadeAssunto>();
builder.Services.AddScoped<IQueryFacade<Autor>, QueryFacadeAutor>();
builder.Services.AddScoped<IQueryFacade<Livro>, QueryFacadeLivro>();
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(DomainModelToViewModelProfile)));

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(CommandBus))!);
    cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(CreateAssuntoCommandHandler))!);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio.API v1");
        c.DocExpansion(DocExpansion.None);
    });
}

//app.UseHttpsRedirection();

app.UseCors("CORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
