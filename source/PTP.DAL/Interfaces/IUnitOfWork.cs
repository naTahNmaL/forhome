using NHibernate;

namespace PTP.DAL.Interfaces;

public interface IUnitOfWork: IDisposable, ITransaction
{ 
    ISession Session { get; }
    void BeginTransaction();
}