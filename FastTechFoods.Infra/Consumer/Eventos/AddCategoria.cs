using Consumer.Model;
using Core.Entities;
using Infrastructure.Repository;
using MassTransit;

namespace Consumer.Eventos;
public class AddCategoria(IRepository<Categoria> repository) : IConsumer<CategoriaDto>
{
    public Task Consume(ConsumeContext<CategoriaDto> context)
    {
        repository.InsertAsync(context.Message.ToEntity());

        return Task.CompletedTask;
    }
}
