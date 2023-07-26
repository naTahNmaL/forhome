using AutoMapper;
using NHibernate;
using PTP.BusinessService.Interfaces;
using PTP.BusinessService.Models;

using PTP.DAL.Domains;
using PTP.DAL.Interfaces;


namespace PTP.BusinessService.Services;

public class CountryServices : ICountryServices
{
    private readonly ICountryRepository _countryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CountryServices(ICountryRepository countryRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<IList<CountryModel>> GetAllAsync()
    {
        
            _unitOfWork.BeginTransaction();
            var listFromDb = await _countryRepository.GetAllAsync();
            foreach (var country in listFromDb)
            {
                await NHibernateUtil.InitializeAsync(country.Places);
            }

            _unitOfWork.Commit();
            var countryList = _mapper.Map<IList<Country>, IList<CountryModel>>(listFromDb);
            return countryList;
        
    }
    
    public async Task<CountryModel> GetByIdAsync(int id)
    {
       
            _unitOfWork.BeginTransaction();
            var itemFromDb = await _countryRepository.GetByIdAsync(id);
            await NHibernateUtil.InitializeAsync(itemFromDb.Places);
            _unitOfWork.Commit();
            var country = _mapper.Map<Country, CountryModel>(itemFromDb);
            return country;
        
        
    }
    
}