using NHibernate;
using NHibernate.Cfg;
namespace PIM.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
