
using KR.Hanyang.Mindwatch.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace KR.Hanyang.Mindwatch.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            // My own Services
            // Coming...

            // Infrastructure stuff
            builder.Services.AddPersistanceServices(builder.Configuration);

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Apply migrations on startup
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MindwatchDbContext>();
            context.Database.Migrate();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                // Seed example data
                DatabaseSeeder.Seed(context);
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Temporary CORS Configuration
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.MapControllers();

            app.Run();
        }
    }
}
