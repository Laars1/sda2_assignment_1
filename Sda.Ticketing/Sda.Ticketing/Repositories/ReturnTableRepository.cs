using Microsoft.EntityFrameworkCore;
using Sda.Ticketing.Abstractions;
using Sda.Ticketing.Persistance;
using Sda.Ticketing.Persistance.Entities;

namespace Sda.Ticketing.Repositories;

public class ReturnTableRepository : IReturnTableRepository
{
    private readonly AppDbContext _context;

    public ReturnTableRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(ReturnTable entity)
    {
        _context.ReturnTables.Add(entity);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        ReturnTable? entry = await _context.ReturnTables.FirstOrDefaultAsync(x => x.RTID == id);

        if (entry == null)
        {
            return false;
        }

        _context.ReturnTables.Remove(entry);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> ExistAsync(int id)
    {
        return await _context.ReturnTables.AnyAsync(x => x.RTID == id);
    }

    public async Task<ICollection<ReturnTable>> GetAsync()
    {
        return await _context.ReturnTables.ToListAsync();
    }

    public async Task<ReturnTable?> GetByIdAsync(int id)
    {
        return await _context.ReturnTables.FirstOrDefaultAsync(x => x.RTID == id);
    }

    public async Task<bool> UpdateAsync(ReturnTable entity)
    {
        ReturnTable? entry = await _context.ReturnTables.FirstOrDefaultAsync(x => x.RTID == entity.RTID);

        if (entry == null)
        {
            return false;
        }

        entry.Date = entity.Date;
        entry.Time = entity.Time;
        entry.Refunds = entity.Refunds;
        entry.Exchanges = entity.Exchanges;

        _context.ReturnTables.Update(entry);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }
}
