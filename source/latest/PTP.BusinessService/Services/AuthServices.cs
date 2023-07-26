using AutoMapper;
using PTP.BusinessService.DTO;
using PTP.BusinessService.Interfaces;
using PTP.DAL.Interfaces;


namespace PTP.BusinessService.Services;

public class AuthServices : IAuthServices
{
    private IUserInfoRepository _userInfoRepository;
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public AuthServices(IUserInfoRepository userInfoRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userInfoRepository = userInfoRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<int> Login(UserLoginRequestDTO user)
    {
        _unitOfWork.BeginTransaction();
        var userList = await _userInfoRepository.GetAllAsync();
        _unitOfWork.Commit();
        foreach (var info in userList)
        {
            if (info.UserName == user.UserName && info.Password == user.Password)
            {
                return info.Id;
            }
        }
        return -1;
    }
}