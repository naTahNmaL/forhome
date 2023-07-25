using PTP.BusinessService.Models;

namespace PTP.BusinessService.Interfaces;

public interface IUserInfoServices
{
    // Task<IList<UserInfoModel>> GetAllAsync();
    Task<UserInfoModel> GetByIdAsync(int id);
    // Task UpdateAsync(UserInfoModel user);
}