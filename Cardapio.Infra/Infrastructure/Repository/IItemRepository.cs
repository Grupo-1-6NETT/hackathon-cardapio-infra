using Core.Entities;

namespace Infrastructure.Repository;
public interface IItemRepository
{
    Task<Item> SelectAsync(Guid id);
    Task<Item> InsertAsync(Item entity);
    Task<Item> UpdateAsync(Item entity);
    Task<bool> DeleteAsync(Guid id);
}
