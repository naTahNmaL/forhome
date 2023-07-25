using Common.UnitOfWork;
using NHibernate.Criterion;
using PersistentLayer.Domains;
using ISession = NHibernate.ISession;

namespace PersistentLayer.Repositories
{

    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeByIdAsync(int employeeId);
        Task<IList<Employee>> GetAllEmployeesAsync(List<string> ignoreVisas = default);

        Task<IList<Employee>> GetAllEmployeeByVisasAsync(List<string> visas);
    }


    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            var session = _unitOfWork.GetActiveSession();
            var result = await session.GetAsync<Employee>(employeeId);
            return result;
        }


        public async Task<IList<Employee>> GetAllEmployeesAsync(List<string> ignoreVisas)
        {
            var session = _unitOfWork.GetActiveSession();
            var query = session.QueryOver<Employee>();

            if (ignoreVisas != null && ignoreVisas.Any())
            {
                query.Where(Restrictions.Not(Restrictions.In(Projections.Property<Employee>(x => x.Visa), ignoreVisas)));
            }
            var result = await query.ListAsync();
            return result;
        }


        public async Task<IList<Employee>> GetAllEmployeeByVisasAsync(List<string> visas = default)
        {
            var session = _unitOfWork.GetActiveSession();
            Employee employeeAlias = null;

            var members = await session.QueryOver(() => employeeAlias)
                .Where(Restrictions.In(Projections.Property(() => employeeAlias.Visa), visas))
                .ListAsync<Employee>();

            return members;
        }
    }

}