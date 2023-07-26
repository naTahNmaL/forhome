using NHibernate;
using PTP.DAL.Interfaces;
using ITransaction = NHibernate.ITransaction;

namespace PTP.DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ISessionFactory _sessionFactory;
    private readonly ISession _session;
    private ITransaction _transaction;

    public ISession Session { get { return this._session; }
    }

    public UnitOfWork(INHibernateConfig nHibernateConfig)
    {
        _sessionFactory = nHibernateConfig.SessionFactory;
        _session = _sessionFactory.OpenSession();
        _session.FlushMode = FlushMode.Auto;
    }

    public void BeginTransaction()
    {
        CheckActiveSession();
        _transaction = _session.BeginTransaction();
    }
    
    public void Dispose()
    {
        if (_transaction.IsActive)
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }
       _session.Dispose();
    }
    
    
    public void Commit()
    {
        try
        {
            CheckActiveSession();
            _transaction.Commit();
        }
        catch
        {
            _transaction.Rollback();
            throw;
        }
        finally
        {
            _transaction.Dispose();
        }
    }

    public void Rollback()
    {
        _transaction.Rollback();
        _transaction.Dispose();
    }
    private void CheckActiveSession()
    {
        if (!_session.IsOpen)
        {
            throw new InvalidOperationException("no active session");
        }
    }
    
}