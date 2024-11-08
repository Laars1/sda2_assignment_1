using Sda2.Cart.Persistance.Entites;

namespace Sda2.Cart.Abstractions;

public interface ICartInProgressRepository : IBaseRepository<CartInprogress>
{
    Task<bool> AddCartAsync(int cid, int productId);
    Task<bool> RemoveCartAsync(int cid, int productId);
    Task<bool> AddItemListAsync(int cid, int productId);
    Task<bool> RemoveItemListAsync(int cid, int productId);

    Task<bool> CustomerHasEntriesAsync(int customerId);

    Task<bool> DeleteByCustomerIdAsync(int customerId);
}