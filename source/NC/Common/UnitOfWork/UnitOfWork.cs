using Common.Constants;
using Common.Transactions;
using NHibernate;
using System.Data;
using ISession = NHibernate.ISession;

namespace Common.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ISession OpenSession();

        ISession GetActiveSession();

        void Flush();

        IUnitTransaction BeginTransaction(IsolationLevel level = IsolationLevel.ReadCommitted);

        void Close();
    }


    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISessionFactory _sessionFactory;

        private ISession? _session;
        private IUnitTransaction? _currentTx;

        private bool _isDisposed;

        public UnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public ISession OpenSession()
        {
            _session ??= _sessionFactory.OpenSession();
            return _session;
        }

        public ISession GetActiveSession()
        {
            ThrowInvalidExNoActiveSession();
            return _session!;
        }

        public void Flush()
        {
            ThrowInvalidExNoActiveSession();
            _session!.Flush();
        }

        public void Close()
        {
            _session?.Close();

            _currentTx = null;
            _session = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IUnitTransaction BeginTransaction(IsolationLevel level = IsolationLevel.ReadCommitted)
        {
         
            _session ??= _sessionFactory.OpenSession();

            _session.BeginTransaction(IsolationLevel.ReadCommitted);
            
            
            _currentTx = new UnitTransaction(this);

            return _currentTx;
        }

        private void Dispose(bool disposing)
        {
            if (_isDisposed) return;

            if (disposing)
            {
                _session?.Close();
            }

            _currentTx = null;
            _session = null;

            _isDisposed = true;
        }

        private void ThrowInvalidExNoActiveSession()
        {
            if (_session is null || !_session.IsConnected || !_session.IsOpen)
            {
                throw new InvalidOperationException(ErrorMessageConst.Session_Not_Active);
            }
        }
    }
}
