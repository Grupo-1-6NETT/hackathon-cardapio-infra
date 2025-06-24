using Consumer.Model;
using Core.Entities;
using Infrastructure.Repository;
using MassTransit;

namespace Consumer.Eventos;
public class DeleteItem(IItemRepository repository) : IConsumer<DeleteItemDto>
{
    public Task Consume(ConsumeContext<DeleteItemDto> context)
    {
        repository.DeleteAsync(context.Message.Id);

        return Task.CompletedTask;
    }
}
