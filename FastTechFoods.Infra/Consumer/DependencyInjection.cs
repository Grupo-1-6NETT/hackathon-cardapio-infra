using Consumer.Eventos;
using Core;
using Infrastructure;
using MassTransit;

namespace Consumer;
public static class DependencyInjection
{
    public static IServiceCollection AddConsumerDI(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCoreDi(configuration)
            .AddInfrastructureDi();

        return services;
    }

    public static IServiceCollection ConfigureRabbitMQ(this IServiceCollection services, IConfiguration configuration)
    {
        //var fila = configuration.GetSection("RabbitMQ")["QueueName"] ?? string.Empty;
        var servidor = configuration.GetSection("RabbitMQ")["Hostname"] ?? string.Empty;
        var usuario = configuration.GetSection("RabbitMQ")["Username"] ?? string.Empty;
        var senha = configuration.GetSection("RabbitMQ")["Password"] ?? string.Empty;

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(servidor, "/", h =>
                {
                    h.Username(usuario);
                    h.Password(senha);
                });

                cfg.ReceiveEndpoint(nameof(AddCategoria).ToLower(), e => e.ConfigureConsumer<AddCategoria>(context));

                cfg.ConfigureEndpoints(context);
            });

            x.AddConsumer<AddCategoria>();
        });

        return services;
    }
}
