using MoutsOrder.Application;
using MoutsOrder.Common.HealthChecks;
using MoutsOrder.Common.Logging;
using MoutsOrder.Common.Security;
using MoutsOrder.Common.Validation;
using MoutsOrder.IoC;
using MoutsOrder.ORM;
using MoutsOrder.WebApi.Middleware;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using MoutsOrder.WebApi.Features.Products.GetProduct;
using MoutsOrder.WebApi.Features.Orders.GetOrder;
using Rebus.Config;
using Rebus.ServiceProvider;
using Rebus.RabbitMq;
using Microsoft.Extensions.DependencyInjection;
using MoutsOrder.Common.Configuration;
using MoutsOrder.Application.EventHandlers;


namespace MoutsOrder.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Log.Information("Starting web application");

            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.AddDefaultLogging();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.AddBasicHealthChecks();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DefaultContext>(options =>
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Order.ORM")
                )                
            );

            builder.Services.AddJwtAuthentication(builder.Configuration);

            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            builder.RegisterDependencies();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(ApplicationLayer).Assembly);

            #region REBUS
 
            // Pegando a conexão do appsettings.json
            var rabbitMqConnection = builder.Configuration.GetConnectionString("RabbitMqConnection");
            var queueName = "orders_queue_elano_ambev";

            // Configuração do Rebus usando o Common
            builder.Services.AddRebusConfiguration(rabbitMqConnection, queueName);            

            // Registrar handlers (consumidores dos eventos)
            builder.Services.AutoRegisterHandlersFromAssemblyOf<OrderCreatedEventHandler>();

            #endregion

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(
                    typeof(ApplicationLayer).Assembly,
                    typeof(Program).Assembly
                );
            });

            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp",
                    policy => policy.WithOrigins("http://localhost:4200")
                                    .AllowAnyMethod()
                                    .AllowAnyHeader());
            });

            var app = builder.Build();
            app.UseMiddleware<ValidationExceptionMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAngularApp");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseBasicHealthChecks();

            app.MapControllers();
      
            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
