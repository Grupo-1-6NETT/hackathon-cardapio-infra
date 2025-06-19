using Core.Entities;
using Core.Options;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDi(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>((provider, options) =>
        {
            options.UseNpgsql(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection);
        });

        services.AddScoped<IRepository<Categoria>, Repository<Categoria>>();
        services.AddScoped<IRepository<Cliente>, Repository<Cliente>>();
        services.AddScoped<IRepository<Item>, Repository<Item>>();
        services.AddScoped<IRepository<Pedido>, Repository<Pedido>>();
        services.AddScoped<IRepository<PedidoItem>, Repository<PedidoItem>>();

        return services;
    }
}
