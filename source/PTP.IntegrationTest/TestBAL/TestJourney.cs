using AutoMapper;
using NHibernate;
using PTP.BusinessService.Binding;
using PTP.BusinessService.Interfaces;
using PTP.BusinessService.Services;
using PTP.DAL.Config;
using PTP.DAL.Interfaces;
using PTP.DAL.Repositories;
using PTP.DAL.UnitOfWork;

namespace PTP.IntegrationTest.TestBAL;

[TestFixture]
public class TestJourney
{
    private ISessionFactory _sessionFactory;
    private IUnitOfWork _unitOfWork;
    private IUnitOfWork _unitOfWork2;

    private static IMapper _mapper;
    
    private ICountryServices _countryServices;
    private ICountryRepository _countryRepository;

    private IPlaceServices _placeServices;
    private IPlaceRepository _placeRepository;

    private ICurrencyServices _currencyServices;
    private ICurrencyRepository _currencyRepository;

    private IDefaultDataService _defaultDataService;

    private IUserInfoRepository _userInfoRepository;
    private IUserInfoServices _userInfoServices;
    
    [OneTimeSetUp]
    public void SetupOnce()
    {
        //_sessionFactory = NHibernateConfig.SessionFactory;
        //_mapper = MapperBinding.Configure();
    }

    [SetUp]
    public void SetUp()
    {
        //_unitOfWork = new UnitOfWork(_sessionFactory);
        _countryRepository = new CountryRepository(_unitOfWork);
        _placeRepository = new PlaceRepository(_unitOfWork);
        _currencyRepository = new CurrencyRepository(_unitOfWork);
        _countryServices = new CountryServices(_countryRepository, _unitOfWork, _mapper);
        _placeServices = new PlaceServices(_placeRepository, _unitOfWork, _mapper);
        _currencyServices = new CurrencyServices(_currencyRepository, _unitOfWork, _mapper);
        _defaultDataService = new DefaultDataService(_countryServices, _currencyServices);
        _userInfoRepository = new UserInfoRepository(_unitOfWork);
        _userInfoServices = new UserInfoService(_userInfoRepository, _unitOfWork, _mapper);
    }

    [Test]
    public async Task TestCountryServiceIsWorking()
    {
        var countryList = await _countryServices.GetAllAsync();
        
        Assert.IsNotNull(countryList);
    }
    [Test]
    public async Task GetOneContry()
    {
        var country1 = await _countryServices.GetByIdAsync(1);
     
        Assert.AreEqual("United States", country1.Name);
    }

    [Test]
    public async Task TestPlaceServiceIsWorking()
    {
        var list = await _placeServices.GetAllAsync();
        
        Assert.IsNotNull(list);
    }
    [Test]
    public async Task TestCurrencyServiceWorking()
    {
        var list = await _currencyServices.GetAllAsync();
        
        Assert.IsNotNull(list);
    }
    
    [Test]
    public async Task TestDefault()
    {
        var list = await _defaultDataService.LoadDefaultData();
        
        Assert.IsNotNull(list);
    }
    
    
    [Test]
    public async Task TestUser()
    {
        var list = await _userInfoServices.GetByIdAsync(2);
        
        Assert.IsNotNull(list);
    }
}