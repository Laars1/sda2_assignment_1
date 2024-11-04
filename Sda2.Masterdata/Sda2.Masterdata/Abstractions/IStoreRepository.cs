using Sda2.Masterdata.Persistance.Entities;

namespace Sda2.Masterdata.Abstractions;

public interface IStoreRepository : IBaseRepository<Store>
{
    Task<bool> AddEmployee(int storeId, int employeeId);

    Task<bool> RemoveEmployee(int storeId, int employeeId);
}
