using PIM.DataAccess.UnitOfWorks;
using PIM.DataAccess.Entity;

namespace PIM.DataAccess.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
