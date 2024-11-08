using Sda.Ticketing.Persistance.Entities;

namespace Sda.Ticketing.Abstractions;

public interface ITicketSystemRepository : IBaseRepository<TicketSystem>
{
    Task<bool> CustomerHasEntriesAsync(int customerId);

    Task<bool> DeleteByCustomerIdAsync(int customerId);
}
