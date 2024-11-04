using Microsoft.EntityFrameworkCore;
using Sda2.Masterdata.Abstractions;
using Sda2.Masterdata.Persistance;
using Sda2.Masterdata.Persistance.Entities;

namespace Sda2.Masterdata.Repositories;

public class RegisterTableRepository : IRegisterRepository
{
    private readonly AppDbContext _context;

    public RegisterTableRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(RegistersTable entity)
    {
        _context.RegistersTables.Add(entity);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        RegistersTable? entry = await _context.RegistersTables.FirstOrDefaultAsync(x => x.RegisterId == id);

        if (entry == null)
        {
            return false;
        }

        _context.RegistersTables.Remove(entry);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> ExistAsync(int id)
    {
        return await _context.RegistersTables.AnyAsync(x => x.RegisterId == id);
    }

    public async Task<ICollection<RegistersTable>> GetAsync()
    {
        return await _context.RegistersTables
            .Include(x => x.OpenEmployee)
            .Include(x => x.CloseEmployee)
            .Include(x => x.DropEmployee)
            .ToListAsync();
    }

    public async Task<RegistersTable?> GetByIdAsync(int id)
    {
        return await _context.RegistersTables
            .Include(x => x.OpenEmployee)
            .Include(x => x.CloseEmployee)
            .Include(x => x.DropEmployee)
            .FirstOrDefaultAsync(x => x.RegisterId == id);
    }

    public async Task<bool> UpdateAsync(RegistersTable entity)
    {
        RegistersTable? entry = await _context.RegistersTables.FirstOrDefaultAsync(x => x.RegisterId == entity.RegisterId);

        if (entry == null)
        {
            return false;
        }

        entry.CloseEmpId = entity.CloseEmpId;
        entry.CloseTime = entity.CloseTime;
        entry.CloseTotal = entity.CloseTotal;
        entry.DropEmpId = entity.DropEmpId;
        entry.DropTime = entity.DropTime;
        entry.DropTotal = entity.DropTotal;
        entry.Note = entity.Note;
        entry.OpenEmpId = entity.OpenEmpId;
        entry.RegisterNum = entity.RegisterNum;

        _context.RegistersTables.Update(entry);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }
}
