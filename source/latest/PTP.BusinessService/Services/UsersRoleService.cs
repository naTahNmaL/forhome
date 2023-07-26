using AutoMapper;
using PTP.BusinessService.Interfaces;
using PTP.BusinessService.Models;
using PTP.DAL.Domains;
using PTP.DAL.Interfaces;

namespace PTP.BusinessService.Services;
public class UsersRoleService 
{
    private readonly IUsersRoleRepository _usersRoleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public UsersRoleService(IUsersRoleRepository usersRoleRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _usersRoleRepository = usersRoleRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // public async Task<IList<UsersRoleModel>> GetAllAsync()
    // {
    //     
    //     var listFromDb = await _usersRoleRepository.GetAllAsync();
    //     _unitOfWork.Commit();
    //     var roles = _mapper.Map<IList<UsersRole>, IList<UsersRoleModel>>(listFromDb);
    //     return roles;
    // }
    //
    // public async Task<UsersRoleModel> GetByIdAsync(int id)
    // {
    //     _unitOfWork.BeginTransaction();
    //     var itemFromDb = await _usersRoleRepository.GetByIdAsync(id);
    //     _unitOfWork.Commit();
    //     var role = _mapper.Map<UsersRole,UsersRoleModel>(itemFromDb);
    //     return role;
    // }
}