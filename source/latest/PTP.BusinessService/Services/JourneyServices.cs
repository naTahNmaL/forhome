using AutoMapper;
using PTP.BusinessService.Interfaces;
using PTP.BusinessService.Models;
using PTP.DAL.Domains;
using PTP.DAL.Interfaces;

namespace PTP.BusinessService.Services;

public class JourneyServices : IJourneyServices
{
    private readonly IJourneyRepository _journeyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public JourneyServices(IJourneyRepository journeyRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _journeyRepository = journeyRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    
    public async Task<JourneyModel> GetAllJourneyByUserId(int id)
    {
        _unitOfWork.BeginTransaction();
        var itemFromDb = await _journeyRepository.GetByIdAsync(id);
        _unitOfWork.Commit();
        var journey = _mapper.Map<Journey,JourneyModel>(itemFromDb);
        return journey;
    }
    //
    // // public Task CreateAsync(JourneyModel journey)
    // // {
    // //     throw new NotImplementedException();
    // // }
    // //
    // // public Task UpdateAsync(JourneyModel journey)
    // // {
    // //     throw new NotImplementedException();
    // // }
    // //
    // // public Task DeleteAsync(int id)
    // // {
    // //     throw new NotImplementedException();
    // // }
}