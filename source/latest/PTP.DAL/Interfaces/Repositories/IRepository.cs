namespace PTP.DAL.Interfaces;

public interface IRepository<T> where T : class
{
    Task<IList<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}