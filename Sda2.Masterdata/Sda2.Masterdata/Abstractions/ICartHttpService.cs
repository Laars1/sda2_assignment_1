namespace Sda2.Masterdata.Abstractions;

public interface ICartHttpService
{
    Task<bool> DeleteCartInprogressAsync(int customerId);
}
