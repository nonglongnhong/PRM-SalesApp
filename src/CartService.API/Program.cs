using System;

using Microsoft.EntityFrameworkCore;

using CartService.API.Data;

namespace CartService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<CartDbContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionDB")));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            const string CorsPolicy = "SalesAppCors";
            builder.Services.AddCors(opts =>
            {
                opts.AddPolicy(CorsPolicy, p => p
                    .WithOrigins("http://localhost:8001", "http://localhost:5173", "http://localhost:3000")
                    .AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(CorsPolicy);

            app.MapControllers();

            app.Run();
        }
    }
}
