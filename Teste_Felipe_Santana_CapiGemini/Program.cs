using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Teste_Felipe_Santana_CapiGemini.Data;
using Teste_Felipe_Santana_CapiGemini.Repositories;
using Teste_Felipe_Santana_CapiGemini.Repositories.Interfaces;
using Teste_Felipe_Santana_CapiGemini.Service;
using Teste_Felipe_Santana_CapiGemini.Service.Interfaces;

namespace Teste_Felipe_Santana_CapiGemini;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("PoliticaCors",
                policy =>
                {
                    policy.AllowAnyOrigin()
                          //.WithOrigins("https://seusite.com", "https://outrosite.com")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
        });

        //INSTANCIA BASE DE DADOS
        builder.Services.AddEntityFrameworkSqlServer()
            .AddDbContext<SistemaTarefasDbcontex>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
            );  

        builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();
        builder.Services.AddScoped<ITarefaService, TarefaService>();
        builder.Services.AddScoped<IUsuarioService, UsuarioService>();

        //FluentValidation
        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseCors("PoliticaCors");

        app.MapControllers();

        app.Run();
    }
}
