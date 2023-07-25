using AutoMapper;
using PTP.BusinessService.Interfaces;
using PTP.BusinessService.Models;
using PTP.DAL.Domains;
using PTP.DAL.Interfaces;
namespace PTP.BusinessService.Services;

public class CurrencyServices : ICurrencyServices
{
    private readonly ICurrencyRepository _currencyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public CurrencyServices(ICurrencyRepository currencyRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _currencyRepository = currencyRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IList<CurrencyModel>> GetAllAsync()
    {
      
            _unitOfWork.BeginTransaction();
            var listFromDb = await _currencyRepository.GetAllAsync();
            _unitOfWork.Commit();
            var currencyList = _mapper.Map<IList<Currency>, IList<CurrencyModel>>(listFromDb);
            return currencyList;
        
    }
}