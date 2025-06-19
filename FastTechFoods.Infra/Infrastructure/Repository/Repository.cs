using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class Repository<T>(AppDbContext context) : IRepository<T> where T : class, IKeyedModel
{
    private DbSet<T> Items => context.GetSet<T>();

    public async Task<T> Select(Guid id) => await Items.SingleAsync(x => x.Id == id);

    public async Task<bool> Delete(Guid id)
    {
        var item = await Items.SingleAsync(x => x.Id == id);
        Items.Remove(item);        
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<T> Insert(T entity)
    {
        Items.Add(entity);
        await context.SaveChangesAsync();        
        return entity;
    }

    public async Task<T> Update(T entity)
    {
        Items.Attach(entity);
        await context.SaveChangesAsync();
        return entity;
    }
}
