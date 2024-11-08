using Microsoft.EntityFrameworkCore;
using Sda.Ticketing.Abstractions;
using Sda.Ticketing.Persistance;
using Sda.Ticketing.Persistance.Entities;

namespace Sda.Ticketing.Repositories;

public class TicketSystemRepository : ITicketSystemRepository
{
    private readonly AppDbContext _context;

    public TicketSystemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(TicketSystem entity)
    {
        _context.TicketSystems.Add(entity);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> CustomerHasEntriesAsync(int customerId)
    {
        return await _context.TicketSystems.AnyAsync(x => x.CustomerId == customerId);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        TicketSystem? entry = await _context.TicketSystems.FirstOrDefaultAsync(x => x.TicketId == id);

        if (entry == null)
        {
            return false;
        }

        _context.TicketSystems.Remove(entry);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> DeleteByCustomerIdAsync(int customerId)
    {
        ICollection<TicketSystem> entries = await _context.TicketSystems.Where(x => x.CustomerId == customerId).ToListAsync();

        if (entries.Count == 0) {
            return true;
        }

        _context.TicketSystems.RemoveRange(entries);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> ExistAsync(int id)
    {
        return await _context.TicketSystems.AnyAsync(x => x.TicketId == id);
    }

    public async Task<ICollection<TicketSystem>> GetAsync()
    {
        return await _context.TicketSystems
            .Include(x => x.ReturnTables)
            .Include(x => x.GiftCards)
            .ToListAsync();
    }

    public async Task<TicketSystem?> GetByIdAsync(int id)
    {
        return await _context.TicketSystems.FirstOrDefaultAsync(x => x.TicketId == id);
    }

    public async Task<bool> UpdateAsync(TicketSystem entity)
    {
        TicketSystem? entry = await _context.TicketSystems.FirstOrDefaultAsync(x => x.TicketId == entity.TicketId);

        if (entry == null)
        {
            return false;
        }

        entry.CartPurchase = entity.CartPurchase;
        entry.Cash = entry.Cash;
        entry.CompanyName = entity.CompanyName;
        entry.Cost = entity.Cost;
        entry.Credit = entry.Credit;
        entry.CustomerId = entity.CustomerId;
        entry.Date = entity.Date;
        entry.Discount = entity.Discount;
        entry.EmployeeId = entity.EmployeeId;
        entry.Quantity = entity.Quantity;
        entry.Subtotal = entity.Subtotal;
        entry.Tax = entity.Tax;
        entry.TaxRate = entity.TaxRate;
        entry.Time = entity.Time;
        entry.Total = entity.Total;

        _context.TicketSystems.Update(entry);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }
}