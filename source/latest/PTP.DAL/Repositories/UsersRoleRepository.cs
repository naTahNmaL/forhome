using NHibernate;
using PTP.DAL.Domains;
using PTP.DAL.Interfaces;

namespace PTP.DAL.Repositories;

public class UsersRoleRepository : Repository<UsersRole>, IUsersRoleRepository
{
    public UsersRoleRepository(IUnitOfWork unitOfWork): base(unitOfWork)
    {
    }
}