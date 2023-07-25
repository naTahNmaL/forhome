using NHibernate;
using PTP.DAL;
using PTP.DAL.Config;
using PTP.DAL.Domains;
using PTP.DAL.Interfaces;
using PTP.DAL.Repositories;
using PTP.DAL.UnitOfWork;

namespace PTP.UnitTest;

public class Tests
{
    private ISessionFactory _sessionFactory;
    private IUnitOfWork _unitOfWork;
    
    private IRepository<Country> _countryRepository;
    private IRepository<Place> _placeRepository;
    private IRepository<Journey> _journeyRepo;
    private IRepository<Currency> _currRepo;
    private IRepository<UserInfo> _userRepo;
    private IRepository<UsersRole> _userRole;

    private IRepository<UserAvatar> _avatar;
    [OneTimeSetUp]
    public void SetupOnce()
    {
        _sessionFactory = NHibernateConfig.SessionFactory;
    }
    [SetUp]
    public void Setup()
    {
        _unitOfWork = new UnitOfWork(_sessionFactory);
        _countryRepository = new CountryRepository(_unitOfWork);
        _placeRepository = new PlaceRepository(_unitOfWork);
 
       _journeyRepo = new JourneyRepository(_unitOfWork);
       _currRepo = new CurrencyRepository(_unitOfWork);
       _userRepo = new UserInfoRepository(_unitOfWork);
       _userRole = new UsersRoleRepository(_unitOfWork);
       _avatar = new UserAvatarRepository(_unitOfWork);
    }
    [Test]
    public void Connect()
    {
        Assert.IsNotNull(_sessionFactory);
        Assert.IsNotNull(_unitOfWork);
    }

    //Test nay chi de test gia tri chua co tao test hoan chinh
    [Test]
    public async Task GetAllData()
    {
        var list = await _countryRepository.GetAllAsync();
        var pl =  await _placeRepository.GetAllAsync();
         var a = await _avatar.GetAllAsync();
        var c = await _currRepo.GetAllAsync();
        var j = await _journeyRepo.GetAllAsync();
        var u = await _userRepo.GetAllAsync();
        var x = await _userRole.GetAllAsync();

        Assert.IsNotNull(u);
    }
}