using NHibernate;
using PTP.DAL.Domains;
using PTP.DAL.Interfaces;

namespace PTP.DAL.Repositories;

public class CurrencyRepository : Repository<Currency>,ICurrencyRepository
{
    public CurrencyRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}