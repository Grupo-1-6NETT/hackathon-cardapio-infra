using Core.Dto;
using Core.Entities;

namespace Infrastructure.Repository;
public interface IItemRepository
{
    Task<Item?> SelectAsync(Guid id);
    Task<Item> InsertAsync(Item entity);
    Task<Item> UpdateAsync(ItemDto entity);
    Task DeleteAsync(Guid id);
}
