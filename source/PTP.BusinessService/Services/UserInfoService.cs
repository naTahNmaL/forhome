using AutoMapper;
using NHibernate;
using PTP.BusinessService.Interfaces;
using PTP.BusinessService.Models;
using PTP.DAL.Domains;
using PTP.DAL.Interfaces;

namespace PTP.BusinessService.Services;

public class UserInfoService : IUserInfoServices
{
    private readonly IUserInfoRepository _userInfoRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public UserInfoService(IUserInfoRepository userInfoRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userInfoRepository = userInfoRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    // public async Task<IList<UserInfoModel>> GetAllAsync()
    // {
    //     _unitOfWork.BeginTransaction();
    //     var listFromDb = await _userInfoRepository.GetAllAsync();
    //     _unitOfWork.Commit();
    //     var users = _mapper.Map<IList<UserInfo>, IList<UserInfoModel>>(listFromDb);
    //     return users;
    // }
    //
    public async Task<UserInfoModel> GetByIdAsync(int id)
    {
        _unitOfWork.BeginTransaction();
        var itemFromDb = await _userInfoRepository.GetByIdAsync(id);
        // await NHibernateUtil.InitializeAsync(itemFromDb.Journeys);
        // await NHibernateUtil.InitializeAsync(itemFromDb.Avatar);
        _unitOfWork.Commit();
        var user = _mapper.Map<UserInfo,UserInfoModel>(itemFromDb);
        return user;
    }
    // public async Task UpdateAsync(UserInfoModel user)
    // {
    //     _unitOfWork.BeginTransaction();
    //
    //     var existingUser = await _userInfoRepository.GetByIdAsync(user.Id);
    //     if (existingUser == null)
    //     {
    //         throw new ArgumentException($"User with ID {user.Id} not found.");
    //     }
    //
    //     _mapper.Map(user, existingUser);
    //     await _userInfoRepository.UpdateAsync(existingUser);
    //
    //     _unitOfWork.Commit();
    // }
}