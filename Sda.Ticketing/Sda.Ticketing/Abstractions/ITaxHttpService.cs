using Sda.Ticketing.Models;

namespace Sda.Ticketing.Abstractions;

public interface ITaxHttpService
{
    Task<Tax?> GetTaxFromFaas(int year, float price);
}
