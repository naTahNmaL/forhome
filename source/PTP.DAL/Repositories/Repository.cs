using NHibernate;
using PTP.DAL.Interfaces;

namespace PTP.DAL.Repositories;

public class Repository<T> : IRepository<T> where T: class
{
    private readonly IUnitOfWork _unitOfWork;
    public Repository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    protected ISession Session { get { return _unitOfWork.Session; } }
    public async Task<IList<T>> GetAllAsync()
    {
        return await Session.QueryOver<T>().ListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
       return await Session.GetAsync<T>(id);
    }
    public async Task CreateAsync(T entity)
    {
        await Session.SaveAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        await Session.UpdateAsync(entity);
        await Session.FlushAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await Session.DeleteAsync(_unitOfWork.Session.LoadAsync<T>(id));
        await Session.FlushAsync();
    }
}