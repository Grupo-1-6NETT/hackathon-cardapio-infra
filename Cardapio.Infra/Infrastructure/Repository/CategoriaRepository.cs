using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class CategoriaRepository(AppDbContext context) : ICategoriaRepository
{
    private DbSet<Categoria> _entitySet => context.Categorias;
    private IQueryable<Categoria> _queryable => context.Categorias.AsNoTracking();
    

    public async Task<Categoria?> SelectAsync(Guid id) => await _queryable.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<bool> DeleteAsync(Guid id)
    {
        var item = await _entitySet.SingleAsync(x => x.Id == id);
        _entitySet.Remove(item);        
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<Categoria> InsertAsync(Categoria entity)
    {
        entity.DataCriacao = DateTime.Now.ToUniversalTime();
        entity.DataAtualizacao = DateTime.Now.ToUniversalTime();
        _entitySet.Add(entity);
        await context.SaveChangesAsync();        
        return entity;
    }

    public async Task<Categoria> UpdateAsync(Categoria entity)
    {
        entity.DataAtualizacao = DateTime.Now.ToUniversalTime();
        _entitySet.Attach(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<Categoria?> GetByNomeAsync(string nome)
    {
        return await _queryable.FirstOrDefaultAsync(x => x.Nome.Trim().ToLower() == nome.Trim().ToLower());
    }
}
