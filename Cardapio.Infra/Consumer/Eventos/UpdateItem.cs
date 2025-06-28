using Consumer.Model;
using Core.Dto;
using Core.Entities;
using Infrastructure.Repository;
using MassTransit;

namespace Consumer.Eventos;
public class UpdateItem(IItemRepository itemRepository, ICategoriaRepository categoriaRepository) : IConsumer<UpdateItemDto>
{
    public async Task Consume(ConsumeContext<UpdateItemDto> context)
    {
        var dto = context.Message;

        var itemDto = new ItemDto
        {
            Id = dto.Id,
            Nome = dto.Nome,
            Preco = dto.Preco,
            Descricao = dto.Descricao,
            Disponivel = dto.Disponivel            
        };

        if (!string.IsNullOrEmpty(dto.NomeCategoria) && !string.IsNullOrEmpty(dto.NomeCategoria))
        {
            var categoria = await categoriaRepository.GetByNomeAsync(dto.NomeCategoria);
            categoria ??= await categoriaRepository.InsertAsync(new Categoria { Nome = dto.NomeCategoria.Trim() });

            itemDto.CategoriaId = categoria.Id;
        }

        await itemRepository.UpdateAsync(itemDto);
    }
}
