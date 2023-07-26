using PTP.BusinessService.Models;

namespace PTP.BusinessService.Interfaces;

public interface IUsersRoleServices
{
    Task<IList<UsersRoleModel>> GetAllAsync();
    Task<UsersRoleModel> GetByIdAsync(int id);
}