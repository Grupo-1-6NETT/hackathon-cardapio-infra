using Core.Entities;

namespace Infrastructure.Repository;
public interface ICategoriaRepository
{
    Task<Categoria?> GetByNomeAsync(string nome);
    Task<Categoria?> SelectAsync(Guid id);
    Task<Categoria> InsertAsync(Categoria entity);
    Task<Categoria> UpdateAsync(Categoria entity);
    Task<bool> DeleteAsync(Guid id);
}
