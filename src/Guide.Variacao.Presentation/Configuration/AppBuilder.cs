using AutoMapper;
using Guide.Variacao.Core.Domain.Mapper;
using Guide.Variacao.Core.Domain.Models;
using Guide.Variacao.Core.Domain.ViewModels;
using Guide.Variacao.Presentation.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Guide.Variacao.Presentation.Configuration
{
    public static class AppBuilder
    {
        public static WebApplication GetApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args).Configure();

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddAutoMapper(config => { 
                config.AddProfile<ModelToViewModelMappingProfile>(); 
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            return app;
        }
    }
}
