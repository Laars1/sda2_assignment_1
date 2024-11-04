using Microsoft.EntityFrameworkCore;
using Sda2.Masterdata.Abstractions;
using Sda2.Masterdata.Persistance;
using Sda2.Masterdata.Persistance.Entities;

namespace Sda2.Masterdata.Repositories;

public class EmployeeRepostiory : IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepostiory(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(EmployeeInfo entity)
    {
        _context.EmployeeInfos.Add(entity);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        EmployeeInfo? entry = await _context.EmployeeInfos.FirstOrDefaultAsync(x => x.EmployeeId == id);

        if (entry == null)
        {
            return false;
        }

        _context.EmployeeInfos.Remove(entry);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> ExistAsync(int id)
    {
        return await _context.EmployeeInfos.AnyAsync(x => x.EmployeeId == id);
    }

    public async Task<ICollection<EmployeeInfo>> GetAsync()
    {
        return await _context.EmployeeInfos
            .Include(x => x.Stores)
            .Include(x => x.OpenRegisters)
            .Include(x => x.CloseRegisters)
            .Include(x => x.DropRegisters)
            .Include(x => x.Customers)
            .ToListAsync();
    }

    public async Task<EmployeeInfo?> GetByIdAsync(int id)
    {
        return await _context.EmployeeInfos
            .Include(x => x.Stores)
            .Include(x => x.OpenRegisters)
            .Include(x => x.CloseRegisters)
            .Include(x => x.DropRegisters)
            .Include(x => x.Customers)
            .FirstOrDefaultAsync(x => x.EmployeeId == id);
    }

    public async Task<bool> UpdateAsync(EmployeeInfo entity)
    {
        EmployeeInfo? entry = await _context.EmployeeInfos.FirstOrDefaultAsync(x => x.EmployeeId == entity.EmployeeId);

        if (entry == null)
        {
            return false;
        }

        entry.AmountOfStores = entity.AmountOfStores;
        entry.City = entity.City;
        entry.CompanyName = entity.CompanyName;
        entry.Email = entity.Email;
        entry.FirstName = entity.FirstName;
        entry.LastName = entity.LastName;
        entry.Password = entity.Password;
        entry.PhoneNumber = entity.PhoneNumber;
        entry.PinNumber = entity.PinNumber;
        entry.Snn = entity.Snn;
        entry.StartDate = entity.StartDate;
        entry.State = entity.State;
        entry.StreetAddress = entity.StreetAddress;
        entry.ZipCode = entity.ZipCode;
        entry.UserType = entity.UserType;

        _context.EmployeeInfos.Update(entry);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }
}
