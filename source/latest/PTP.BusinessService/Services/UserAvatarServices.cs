using AutoMapper;
using PTP.BusinessService.Interfaces;
using PTP.BusinessService.Models;
using PTP.DAL.Domains;
using PTP.DAL.Interfaces;

namespace PTP.BusinessService.Services;
public class UserAvatarServices {
    private readonly IUserAvatarRepository _userAvatarRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public UserAvatarServices(IUserAvatarRepository userAvatarRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userAvatarRepository = userAvatarRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // public async Task<IList<UserAvatarModel>> GetAllAsync()
    // {
    //     _unitOfWork.BeginTransaction();
    //     var listFromDb = await _userAvatarRepository.GetAllAsync();
    //     _unitOfWork.Commit();
    //     var avatarsList = _mapper.Map<IList<UserAvatar>, IList<UserAvatarModel>>(listFromDb);
    //     return avatarsList;
    // }
    //
    // public async Task<UserAvatarModel> GetByIdAsync(int id)
    // {
    //     _unitOfWork.BeginTransaction();
    //     var itemFromDb = await _userAvatarRepository.GetByIdAsync(id);
    //     _unitOfWork.Commit();
    //     var avatar = _mapper.Map<UserAvatar,UserAvatarModel>(itemFromDb);
    //     return avatar;
    // }
}