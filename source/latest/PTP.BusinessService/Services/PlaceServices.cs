using AutoMapper;
using PTP.BusinessService.Interfaces;
using PTP.BusinessService.Models;
using PTP.DAL.Domains;
using PTP.DAL.Interfaces;

namespace PTP.BusinessService.Services;

public class PlaceServices : IPlaceServices
{
    private readonly IPlaceRepository _placeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PlaceServices(IPlaceRepository placeRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _placeRepository = placeRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IList<PlaceModel>> GetAllAsync()
    {
        _unitOfWork.BeginTransaction();
        var listFromDb = await _placeRepository.GetAllAsync();
        _unitOfWork.Commit();
        var placeList = _mapper.Map<IList<Place>, IList<PlaceModel>>(listFromDb);
        return placeList;
    }
}
