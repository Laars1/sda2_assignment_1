using Microsoft.EntityFrameworkCore;
using Sda2.Masterdata.Abstractions;
using Sda2.Masterdata.Persistance;
using Sda2.Masterdata.Persistance.Entities;

namespace Sda2.Masterdata.Repositories;

public class StoresRepository : IStoreRepository
{
    private readonly AppDbContext _context;
    private readonly IEmployeeRepository _employeeRepository;

    public StoresRepository(AppDbContext context, IEmployeeRepository employeeRepository)
    {
        _context = context;
        _employeeRepository = employeeRepository;
    }

    public async Task<bool> AddAsync(Store entity)
    {
        _context.Stores.Add(entity);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> AddEmployee(int storeId, int employeeId)
    {
        Store? entry = await _context.Stores
            .Include(x => x.EmployeeInfos)
            .FirstOrDefaultAsync(x => x.SID == storeId);

        EmployeeInfo? employee = await _employeeRepository.GetByIdAsync(employeeId);

        if (entry == null || employee == null)
        {
            return false;
        }

        if (!entry.EmployeeInfos.Any(x => x.EmployeeId == employeeId))
        {
            entry.EmployeeInfos.Add(employee);
            int changedEntities = await _context.SaveChangesAsync();
            return changedEntities > 0;
        }

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        Store? entry = await _context.Stores.FirstOrDefaultAsync(x => x.SID == id);

        if (entry == null)
        {
            return false;
        }

        _context.Stores.Remove(entry);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> ExistAsync(int id)
    {
        return await _context.Stores.AnyAsync(x => x.SID == id);
    }

    public async Task<ICollection<Store>> GetAsync()
    {
        return await _context.Stores
            .Include(x => x.EmployeeInfos)
            .ToListAsync();
    }

    public async Task<Store?> GetByIdAsync(int id)
    {
        return await _context.Stores
            .Include(x => x.EmployeeInfos)
            .FirstOrDefaultAsync(x => x.SID == id);
    }

    public async Task<bool> RemoveEmployee(int storeId, int employeeId)
    {
        Store? entry = await _context.Stores
            .Include(x => x.EmployeeInfos)
            .FirstOrDefaultAsync(x => x.SID == storeId);

        EmployeeInfo? employee = await _employeeRepository.GetByIdAsync(employeeId);

        if (entry == null || employee == null)
        {
            return false;
        }

        if (entry.EmployeeInfos.Any(x => x.EmployeeId == employeeId))
        {
            entry.EmployeeInfos.Remove(employee);
            int changedEntities = await _context.SaveChangesAsync();
            return changedEntities > 0;
        }

        return true;
    }

    public async Task<bool> UpdateAsync(Store entity)
    {
        Store? entry = await _context.Stores.FirstOrDefaultAsync(x => x.SID == entity.SID);

        if (entry == null)
        {
            return false;
        }

        entry.CompanyName = entity.CompanyName;

        _context.Stores.Update(entry);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }
}
