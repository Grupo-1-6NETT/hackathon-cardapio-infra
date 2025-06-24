using Consumer.Model;
using Core.Entities;
using Infrastructure.Repository;
using MassTransit;

namespace Consumer.Eventos;
public class AddItem(IItemRepository itemRepository, ICategoriaRepository categoriaRepository) : IConsumer<AddItemDto>
{
    public async Task Consume(ConsumeContext<AddItemDto> context)
    {
        var dto = context.Message;

        var entity = new Item
        {
            Nome = dto.Nome,
            Descricao = dto.Descricao,
            Disponivel = dto.Disponivel,
            Preco = dto.Preco
        };

        if (!string.IsNullOrEmpty(dto.NomeCategoria))
        {
            var categoria = await categoriaRepository.GetByNomeAsync(dto.NomeCategoria);
            categoria ??= await categoriaRepository.InsertAsync(new Categoria { Nome = dto.NomeCategoria.Trim() });            

            entity.Categoria = categoria;
        }

        await itemRepository.InsertAsync(entity);        
    }
}
