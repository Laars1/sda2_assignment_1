namespace Sda.Ticketing.Abstractions;

public interface IBaseRepository<T> where T : class
{
    Task<ICollection<T>> GetAsync();

    Task<T?> GetByIdAsync(int id);

    Task<bool> AddAsync(T entity);

    Task<bool> UpdateAsync(T entity);

    Task<bool> DeleteAsync(int id);

    Task<bool> ExistAsync(int id);
}