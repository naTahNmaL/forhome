using PIM.DataAccess.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIM.DataAccess.Repository
{
    public interface IProjectRepository: IRepository<Project>
    {
        Task DeleteByProjectNumberListAsync(IList<int> projectNumberList);
        Task<bool> DeleteByProjectNumberAsync(int projectNumber);
        Task<Project> GetProjectByProjectNumber(int projectNumber);
        Task<IList<Project>> GetProjectFilter(string searchString, string status);
    }
}
