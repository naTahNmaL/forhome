using PIM.BusinessService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIM.BusinessService.Service
{
    public interface IGroupService
    {
        Task<IList<GroupModel>> GetAllAsync();
        Task<GroupModel> GetByIdAsync(Guid id);
        Task CreateAsync(GroupModel group);
        Task UpdateAsync(GroupModel group);
        Task DeleteAsync(Guid id);
    }
}