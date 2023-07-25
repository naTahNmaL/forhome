using NHibernate;
using PTP.DAL.Domains;
using PTP.DAL.Interfaces;

namespace PTP.DAL.Repositories;

public class UserInfoRepository : Repository<UserInfo>, IUserInfoRepository
{
    public UserInfoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}