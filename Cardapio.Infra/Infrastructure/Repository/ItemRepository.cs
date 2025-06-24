using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class ItemRepository(AppDbContext context) : IItemRepository
{
    private DbSet<Item> _entitySet => context.Items;
    private IQueryable<Item> _queryable => context.Items.AsNoTracking();
    

    public async Task<Item> SelectAsync(Guid id) => await _queryable.SingleAsync(x => x.Id == id);

    public async Task<bool> DeleteAsync(Guid id)
    {
        var item = await _entitySet.SingleAsync(x => x.Id == id);
        _entitySet.Remove(item);        
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<Item> InsertAsync(Item entity)
    {
        entity.DataCriacao = DateTime.Now.ToUniversalTime();
        _entitySet.Add(entity);
        await context.SaveChangesAsync();        
        return entity;
    }

    public async Task<Item> UpdateAsync(Item entity)
    {
        entity.DataAtualizacao = DateTime.Now.ToUniversalTime();
        _entitySet.Attach(entity);
        await context.SaveChangesAsync();
        return entity;
    }
}
