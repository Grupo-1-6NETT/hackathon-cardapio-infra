using Core.Entities;

namespace Infrastructure.Repository;
public interface IRepository<T> where T: class, IKeyedModel
{
    Task<T> Select(Guid id);
    Task<T> Insert(T entity);
    Task<T> Update(T entity);
    Task<bool> Delete(Guid id);
}
