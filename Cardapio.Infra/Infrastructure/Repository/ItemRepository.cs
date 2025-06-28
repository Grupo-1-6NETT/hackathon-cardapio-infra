using Core.Dto;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class ItemRepository(AppDbContext context) : IItemRepository
{
    private DbSet<Item> EntitySet => context.Items;
    private IQueryable<Item> Queryable => context.Items.AsNoTracking();
    

    public async Task<Item?> SelectAsync(Guid id) => await Queryable.FirstOrDefaultAsync(x => x.Id == id);

    public async Task DeleteAsync(Guid id)
    {
        var item = Queryable
            .Include(x => x.Categoria)
            .FirstOrDefault(x => x.Id == id)
            ?? throw new KeyNotFoundException(nameof(id));
        
        EntitySet.Remove(item);
        await context.SaveChangesAsync();
        
    }

    public async Task<Item> InsertAsync(Item entity)
    {
        entity.Categoria = await context.Categorias.SingleAsync(x => x.Id == entity.Categoria.Id);

        entity.DataCriacao = DateTime.Now.ToUniversalTime();
        entity.DataAtualizacao = DateTime.Now.ToUniversalTime();

        await EntitySet.AddAsync(entity);
        await context.SaveChangesAsync();
        
        return entity;
    }

    public async Task<Item> UpdateAsync(ItemDto dto)
    {
        var current = await EntitySet
            .FirstOrDefaultAsync(x => x.Id == dto.Id)
            ?? throw new KeyNotFoundException(nameof(dto.Id));

        if (!string.IsNullOrEmpty(dto.Nome?.Trim()))
            current.Nome = dto.Nome.Trim();

        if(!string.IsNullOrEmpty(dto.Descricao?.Trim()))
            current.Descricao = dto.Descricao.Trim();

        if(dto.Preco != null && dto.Preco.Value > 0)
            current.Preco = dto.Preco.Value;

        if(dto.Disponivel != null)
            current.Disponivel = dto.Disponivel.Value;

        if (dto.CategoriaId != null && dto.CategoriaId.Value != Guid.Empty && dto.CategoriaId.Value != current.Categoria.Id)
            current.Categoria = await context.Categorias
                .FirstOrDefaultAsync(x => x.Id == dto.CategoriaId.Value)
                ?? throw new KeyNotFoundException(nameof(dto.CategoriaId));
        
        current.DataAtualizacao = DateTime.Now.ToUniversalTime();
        
        EntitySet.Update(current);
        await context.SaveChangesAsync();

        return current;
    }
}
