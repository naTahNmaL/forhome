using PIM.BusinessService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIM.BusinessService.Service
{
    public interface IProjectService
    {
        Task<IList<ProjectModel>> GetAllAsync();
        Task CreateAsync(ProjectViewModel project, string culture);
        Task UpdateAsync(ProjectViewModel project, string culture);
        Task<ProjectModel> GetByProjectNumberAsync(int number);
        Task DeleteProjectListAsync(IList<int> projectNumberList);
        Task DeleteOneProjectAsync(int projectNumber);
        Task<IList<ProjectModel>> GetProjectFilter(string searchString, string status);
    }
}