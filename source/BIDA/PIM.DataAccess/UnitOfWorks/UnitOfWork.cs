using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using PIM.DataAccess.Entity;
using PIM.DataAccess.Commons;

namespace PIM.DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory _sessionFactory;
        private ITransaction _transaction;
        public ISession Session { get; set; }
        
        static UnitOfWork()
        {
            // Initialise singleton instance of ISessionFactory, static constructors are only executed once during the 
            // application lifetime - the first time the UnitOfWork class is used
            _sessionFactory = Fluently.Configure()
                                   .Database(MsSqlConfiguration.MsSql2008
                                                .ConnectionString(CommonConstants.ConnectionStringAtCompany)
                                                )
                                   .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Project>())
                                   .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Employee>())
                                   .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Group>())
                                   .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                                   .BuildSessionFactory();
        }
        
        public UnitOfWork()
        {
            Session = _sessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            if (!Session.IsOpen)
            {
                Session = _sessionFactory!.OpenSession();
                Session.FlushMode = FlushMode.Auto;
            }
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                // commit transaction if there is one active
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Commit();
            }
            catch
            {
                // rollback if there was an exception
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();

                throw;
            }
            finally
            {
                Session.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                Session.Dispose();
            }
        }
    }
}
