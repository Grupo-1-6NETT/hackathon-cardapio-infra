using Consumer.Model;
using Core.Entities;
using Infrastructure.Repository;
using MassTransit;

namespace Consumer.Eventos;
public class UpdateItem(IItemRepository itemRepository, ICategoriaRepository categoriaRepository) : IConsumer<UpdateItemDto>
{
    public async Task Consume(ConsumeContext<UpdateItemDto> context)
    {
        var dto = context.Message;

        var entity = new Item
        {
            Id = dto.Id,
            Nome = dto.Nome ?? string.Empty,
            Descricao = dto.Descricao ?? string.Empty,
            Preco = dto.Preco
        };

        if (!string.IsNullOrEmpty(dto.NomeCategoria))
        {
            var categoria = await categoriaRepository.GetByNomeAsync(dto.NomeCategoria);
            categoria ??= await categoriaRepository.InsertAsync(new Categoria { Nome = dto.NomeCategoria.Trim() });

            entity.Categoria = categoria;
        }

        await itemRepository.UpdateAsync(entity);
    }
}
