namespace Sda2.Masterdata.Abstractions;

public interface ITicketingHttpService
{
    Task<bool> DeleteTicketsAsync(int customerId);
}
