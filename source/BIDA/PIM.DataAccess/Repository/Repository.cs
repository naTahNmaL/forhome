using NHibernate;
using PIM.DataAccess.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIM.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private UnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        protected ISession Session { get { return _unitOfWork.Session; } }

        public virtual async Task<IList<T>> GetAllAsync()
        {
            return await Session.QueryOver<T>().ListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
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
        }

        public async Task DeleteAsync(Guid id)
        {
            await Session.DeleteAsync(Session.LoadAsync<T>(id));
        }
    }
}
