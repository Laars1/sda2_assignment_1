using Microsoft.EntityFrameworkCore;
using Sda2.Masterdata.Abstractions;
using Sda2.Masterdata.Persistance;
using Sda2.Masterdata.Persistance.Entities;

namespace Sda2.Masterdata.Repositories;

public class CustomerInfoRepository : ICustomerInfoRepository
{
    private readonly AppDbContext _context;

    public CustomerInfoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(CustomerInfo entity)
    {
        _context.CustomerInfos.Add(entity);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        CustomerInfo? entry = await _context.CustomerInfos.FirstOrDefaultAsync(x => x.CustomerId == id);

        if (entry == null)
        {
            return false;
        }

        _context.CustomerInfos.Remove(entry);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }

    public async Task<bool> ExistAsync(int id)
    {
        return await _context.CustomerInfos.AnyAsync(x => x.CustomerId == id);
    }

    public async Task<ICollection<CustomerInfo>> GetAsync()
    {
        return await _context.CustomerInfos
            .Include(x => x.EmployeeInfo)
            .ToListAsync();
    }

    public async Task<CustomerInfo?> GetByIdAsync(int id)
    {
        return await _context.CustomerInfos
            .Include(x => x.EmployeeInfo)
            .FirstOrDefaultAsync(x => x.CustomerId == id);
    }

    public async Task<bool> UpdateAsync(CustomerInfo entity)
    {
        CustomerInfo? entry = await _context.CustomerInfos.FirstOrDefaultAsync(x => x.CustomerId == entity.CustomerId);

        if (entry == null)
        {
            return false;
        }

        entry.City = entity.City;
        entry.Email = entity.Email;
        entry.FirstName = entity.FirstName;
        entry.LastName = entity.LastName;
        entry.Password = entity.Password;
        entry.PhoneNumber = entity.PhoneNumber;
        entry.State = entity.State;
        entry.StreetAddress = entity.StreetAddress;
        entry.ZipCode = entity.ZipCode;
        entry.CustomerId = entity.CustomerId;
        entry.Rewards = entity.Rewards;

        _context.CustomerInfos.Update(entry);
        int changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }
}