using NHibernate;
using PTP.DAL.Domains;
using PTP.DAL.Interfaces;

namespace PTP.DAL.Repositories;

public class UserAvatarRepository : Repository<UserAvatar>, IUserAvatarRepository
{
    public UserAvatarRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        
    }
}