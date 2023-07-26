using NHibernate;

namespace PTP.DAL.Interfaces;

public interface INHibernateConfig
{
    ISessionFactory SessionFactory { get; } 
}