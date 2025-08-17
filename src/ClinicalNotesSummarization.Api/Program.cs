using ClinicalNotesSummarization.Application;
using ClinicalNotesSummarization.Application.Mappings;
using ClinicalNotesSummarization.Infrastructure;
using ClinicalNotesSummarization.Infrastructure.Persistence;
using ClinicalNotesSummarization.Orchestration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddDbContext<ClinicalNotesDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"))
        );

        // Add CORS services
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
        });
        builder.Services.AddControllers();


        // Add Swagger services
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Clinical Notes API",
                Description = "An API for managing clinical notes and patient data"
            });
        });
        builder.Services.AddApplicationDependencies();
        builder.Services.AddInfrastructureDependencies();
        builder.Services.AddOrchestrationServices(builder.Configuration);

        MappingConfig.RegisterMappings();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Clinical Notes API v1");
            options.RoutePrefix = "";  // This makes Swagger UI available at the root
        });

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
        // specifying the Swagger JSON endpoint.
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clinical Notes Summarization API v1");
            c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
        });

        app.MapControllers();
        app.Run();
    }
}