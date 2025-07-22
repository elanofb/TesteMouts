using MoutsOrder.Domain.Repositories;
using MoutsOrder.ORM;
using MoutsOrder.ORM.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoutsOrder.Domain.Services;
using MoutsOrder.Application.Services;
using MoutsOrder.Application.Products.CreateProduct;
using FluentValidation;

namespace MoutsOrder.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        builder.Services.AddScoped<IMessageBusService, MessageBusService>();
        //builder.Services.AddScoped<OrderDiscountService>();
        builder.Services.AddScoped<ICartRepository, CartRepository>();
        builder.Services.AddScoped<IValidator<CreateProductCommand>, CreateProductCommandValidator>();
    }
}
