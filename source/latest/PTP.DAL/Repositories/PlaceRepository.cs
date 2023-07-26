using NHibernate;
using PTP.DAL.Domains;
using PTP.DAL.Interfaces;

namespace PTP.DAL.Repositories;

public class PlaceRepository : Repository<Place>,IPlaceRepository
{
    public PlaceRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}