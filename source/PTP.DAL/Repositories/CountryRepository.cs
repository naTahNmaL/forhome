using NHibernate;
using PTP.DAL.Domains;
using PTP.DAL.Interfaces;

namespace PTP.DAL.Repositories;

public class CountryRepository : Repository<Country>, ICountryRepository
{
    public CountryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}