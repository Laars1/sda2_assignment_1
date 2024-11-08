using Microsoft.EntityFrameworkCore;
using Sda2.Cart.Abstractions;
using Sda2.Cart.Persistance;
using Sda2.Cart.Persistance.Entites;

namespace Sda2.Cart.Repositories;

public class CartInprogressRepository : ICartInProgressRepository
{
    private readonly AppDbContext _context;

    public CartInprogressRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(CartInprogress entity)
    {
        _context.CartInprogress.Add(entity);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> AddItemListAsync(int cid, int productId)
    {
        CartInprogress? entry = await GetByIdAsync(cid);

        if (entry == null)
        {
            return false;
        }

        ItemList? itemList = entry.ItemLists.FirstOrDefault(x => x.ProductId == productId);
        if (itemList == null)
        {
            _context.ItemLists.Add(new()
            {
                ProductId = productId,
                Qty = 1
            });
        }
        else
        {
            itemList.Qty = itemList.Qty + 1;
        }

        _context.CartInprogress.Update(entry);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> AddCartAsync(int cid, int productId)
    {
        CartInprogress? entry = await GetByIdAsync(cid);

        if (entry == null) 
        {
            return false;
        }

        Persistance.Entites.Cart? cart = entry.Carts.FirstOrDefault(x => x.ProductId == productId);
        if (cart == null)
        {
            entry.Carts.Add(new()
            {
                ProductId = productId,
                Qty = 1
            });
        }
        else
        {
            cart.Qty = cart.Qty + 1;
        }

        _context.CartInprogress.Update(entry);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        CartInprogress? entry = await _context.CartInprogress.FirstOrDefaultAsync(x => x.CID == id);

        if (entry == null)
        {
            return false;
        }

        _context.CartInprogress.Remove(entry);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> ExistAsync(int id)
    {
        return await _context.CartInprogress.AnyAsync(x => x.CID == id);
    }

    public async Task<ICollection<CartInprogress>> GetAsync()
    {
        return await _context.CartInprogress
            .Include(x => x.Carts)
            .Include(x => x.ItemLists)
            .ToListAsync();
    }

    public async Task<CartInprogress?> GetByIdAsync(int id)
    {
        return await _context.CartInprogress
            .Include(x => x.Carts)
            .Include(x => x.ItemLists)
            .FirstOrDefaultAsync(x => x.CID == id);
    }

    public async Task<bool> RemoveItemListAsync(int cid, int productId)
    {
        CartInprogress? entry = await GetByIdAsync(cid);

        if (entry == null)
        {
            return false;
        }

        ItemList? itemList = entry.ItemLists.FirstOrDefault(x => x.ProductId == productId);
        if (itemList != null)
        {
            itemList.Qty = itemList.Qty - 1;

            if (itemList.Qty <= 0)
            {
                entry.ItemLists.Remove(itemList);
            }
        }

        _context.CartInprogress.Update(entry);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> RemoveCartAsync(int cid, int productId)
    {
        CartInprogress? entry = await GetByIdAsync(cid);

        if (entry == null)
        {
            return false;
        }

        Persistance.Entites.Cart? cart = entry.Carts.FirstOrDefault(x => x.ProductId == productId);
        if (cart != null)
        {
            cart.Qty = cart.Qty - 1;

            if (cart.Qty <= 0)
            {
                entry.Carts.Remove(cart);
            }
        }

        _context.CartInprogress.Update(entry);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> UpdateAsync(CartInprogress entity)
    {
        CartInprogress? entry = await _context.CartInprogress.FirstOrDefaultAsync(x => x.CID == entity.CID);

        if (entry == null)
        {
            return false;
        }

        entry.TicketId = entity.TicketId;
        entry.CustomerId = entity.CustomerId;

        _context.CartInprogress.Update(entry);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> DeleteByCustomerIdAsync(int customerId)
    {
        ICollection<CartInprogress> entries = await _context.CartInprogress
            .Where(x => x.CustomerId == customerId)
            .ToListAsync();

        _context.RemoveRange(entries);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> CustomerHasEntriesAsync(int customerId)
    {
        return await _context.CartInprogress.AnyAsync(x => x.CustomerId == customerId);
    }
}