using Sda2.Cart.Persistance.Entites;

namespace Sda2.Cart.Abstractions;

public interface ICartInProgressRepository : IBaseRepository<CartInprogress>
{
    Task<bool> AddCart(int cid, int productId);
    Task<bool> RemoveCart(int cid, int productId);
    Task<bool> AddItemList(int cid, int productId);
    Task<bool> RemoveItemList(int cid, int productId);

    Task<bool> CustomerHasEntries(int customerId);

    Task<bool> DeleteByCustomerIdAsync(int customerId);
}