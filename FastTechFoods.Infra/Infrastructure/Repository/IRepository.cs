using Core.Entities;

namespace Infrastructure.Repository;
public interface IRepository<T> where T: BaseEntity
{
    Task<T> SelectAsync(Guid id);
    Task<T> InsertAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(Guid id);
}
