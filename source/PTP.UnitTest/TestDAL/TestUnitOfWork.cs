using NHibernate;
using PTP.DAL;
using PTP.DAL.Config;
using PTP.DAL.Interfaces;
using PTP.DAL.UnitOfWork;

namespace PTP.UnitTest;

public class TestUnitOfWork
{
    private ISessionFactory _sessionFactory;
  
    
    [OneTimeSetUp]
    public void SetupOnce()
    {
        _sessionFactory = NHibernateConfig.SessionFactory;
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _sessionFactory.Dispose();
    }

    [Test]
    public void OpenSession_Should_CurrentSession_NotNull()
    {
        // arr
        var uow = new UnitOfWork(_sessionFactory);
        uow.BeginTransaction();
        // assert
        Assert.That(uow, Is.Not.Null);
    }

    
}