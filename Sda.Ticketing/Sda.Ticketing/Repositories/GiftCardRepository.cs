using Microsoft.EntityFrameworkCore;
using Sda.Ticketing.Abstractions;
using Sda.Ticketing.Persistance;
using Sda.Ticketing.Persistance.Entities;

namespace Sda.Ticketing.Repositories;

public class GiftCardRepository : IGiftCardRepository
{
    private readonly AppDbContext _context;

    public GiftCardRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(GiftCard entity)
    {
        _context.GiftCards.Add(entity);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        GiftCard? entry = await _context.GiftCards.FirstOrDefaultAsync(x => x.GiftId == id);

        if (entry == null)
        {
            return false;
        }

        _context.GiftCards.Remove(entry);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> ExistAsync(int id)
    {
        return await _context.GiftCards.AnyAsync(x => x.GiftId == id);
    }

    public async Task<ICollection<GiftCard>> GetAsync()
    {
        return await _context.GiftCards.ToListAsync();
    }

    public async Task<GiftCard?> GetByIdAsync(int id)
    {
        return await _context.GiftCards.FirstOrDefaultAsync(x => x.GiftId == id);
    }

    public async Task<bool> UpdateAsync(GiftCard entity)
    {
        GiftCard? entry = await _context.GiftCards.FirstOrDefaultAsync(x => x.GiftId == entity.GiftId);

        if (entry == null)
        {
            return false;
        }

        entry.PromoNumber = entity.PromoNumber;
        entry.TicketId = entity.TicketId;
        entry.CardBalance = entity.CardBalance;
        entry.CustomerId = entity.CustomerId;

        _context.GiftCards.Update(entry);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }
}
