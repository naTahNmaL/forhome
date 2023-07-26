using NHibernate;
using PTP.DAL.Domains;
using PTP.DAL.Interfaces;

namespace PTP.DAL.Repositories;

public class JourneyRepository: Repository<Journey>, IJourneyRepository
{
    public JourneyRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    } 
    // public async Task<IList<Journey>> GetAllJourneyByUserId(int id)
    // {
    // }
}