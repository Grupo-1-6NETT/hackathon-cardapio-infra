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

        var entity = await itemRepository.SelectAsync(dto.Id) ?? new();

        if (!string.IsNullOrEmpty(dto.Nome))
            entity.Nome = dto.Nome;
        if (!string.IsNullOrEmpty(dto.Descricao))
            entity.Descricao = dto.Descricao;
        if(dto.Preco != null)
            entity.Preco = dto.Preco.Value;        

        if (!string.IsNullOrEmpty(dto.NomeCategoria))
        {
            var categoria = await categoriaRepository.GetByNomeAsync(dto.NomeCategoria);
            categoria ??= await categoriaRepository.InsertAsync(new Categoria { Nome = dto.NomeCategoria.Trim() });

            entity.Categoria = categoria;
        }

        await itemRepository.UpdateAsync(entity);
    }
}
