using PIM.DataAccess.UnitOfWorks;
using PIM.DataAccess.Entity;
namespace PIM.DataAccess.Repository
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
