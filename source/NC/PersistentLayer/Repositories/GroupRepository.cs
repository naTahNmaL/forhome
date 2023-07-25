using Common.UnitOfWork;
using PersistentLayer.Domains;
using ISession = NHibernate.ISession;

namespace PersistentLayer.Repositories
{
    public interface IGroupRepository
    {
        Task<IList<Group>> GetAllGroupsAsync();
        Group GetGroupById(int groupId);
    }

    public class GroupRepository : IGroupRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Group>> GetAllGroupsAsync()
        {
            var session = _unitOfWork.GetActiveSession();
            var result =  await session.QueryOver<Group>().ListAsync();
            return result;
        }

        public Group GetGroupById(int groupId)
        {
            var session = _unitOfWork.GetActiveSession();
            var result =  session.Get<Group>(groupId);
            return result;
        }
    }
}
